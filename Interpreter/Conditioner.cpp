#include "Interpreter.h"

const void Interpreter::Conditioner(size_t i, toks& tokens, iftoks& ifTokens, vars& variables)
{
    bool conditionStarted = false;
    bool isIFBody = false;
    bool isELSEBody = false;
    size_t conditionFirst = 0;
    size_t conditionNumber = 0;
    int ifSeen = 0;
    while (i < tokens.size())
    {
        if (tokens[i].first == TokenType::KEYWORD && tokens[i].second == "IF" && !isIFBody && !isELSEBody)
        {
            conditionStarted = true;
            conditionFirst = i;
            i++;
        }
        else if (tokens[i].first == TokenType::KEYWORD && tokens[i].second == "IF" && (isIFBody || isELSEBody))
        {
            ifSeen++;

            if (isIFBody)
                std::get<0>(ifTokens[conditionNumber]).push_back(tokens[i]);
            else if (isELSEBody)
                std::get<1>(ifTokens[conditionNumber]).push_back(tokens[i]);

            tokens.erase(tokens.begin() + i);
        }
        else if (conditionStarted
            && (tokens[i].first == TokenType::EXPRESSION || tokens[i].first == TokenType::NUMBER || tokens[i].first == TokenType::VARIABLE)
            && !isIFBody && !isELSEBody)
        {
            tok result = CheckCondition(tokens[i], tokens[i + 2], tokens[i + 1], variables);
            tokens[i] = result;
            tokens.erase(tokens.begin() + i + 1);
            tokens.erase(tokens.begin() + i + 1);
            i++;
        }
        else if (!conditionStarted && tokens[i].first == TokenType::KEYWORD && tokens[i].second == "ENDIF"
            && (isIFBody || isELSEBody) && ifSeen != 0)
        {
            ifSeen--;

            if (isIFBody)
                std::get<0>(ifTokens[conditionNumber]).push_back(tokens[i]);
            else if (isELSEBody)
                std::get<1>(ifTokens[conditionNumber]).push_back(tokens[i]);

            tokens.erase(tokens.begin() + i);
        }
        else if (!conditionStarted && tokens[i].first == TokenType::KEYWORD && tokens[i].second == "ENDIF"
            && (isIFBody || isELSEBody) && ifSeen == 0)
        {
            conditionNumber++;
            isIFBody = false;
            isELSEBody = false;
            conditionStarted = false;
            tokens.erase(tokens.begin() + i);
            return;
        }
        else if ((!conditionStarted && tokens[i].first == TokenType::KEYWORD && tokens[i].second == "ELSE") || isELSEBody)
        {
            if (!isELSEBody)
            {
                isIFBody = false;
                isELSEBody = true;
            }
            else
            {
                std::get<1>(ifTokens[conditionNumber]).push_back(tokens[i]);
            }
            tokens.erase(tokens.begin() + i);
        }
        else if ((conditionStarted && tokens[i].first == TokenType::KEYWORD && tokens[i].second == "THEN") || isIFBody)
        {
            if (!isIFBody)
            {
                conditionStarted = false;
                isIFBody = true;
                isELSEBody = false;
                tokens[conditionFirst].first = TokenType::STATEMENT;
                tokens[conditionFirst].second = std::to_string(conditionNumber);
                ifTokens.push_back(std::make_tuple(toks(), toks()));
            }
            else
            {
                std::get<0>(ifTokens[conditionNumber]).push_back(tokens[i]);
            }
            tokens.erase(tokens.begin() + i);
        }
        else
        {
            i++;
        }
    }
}