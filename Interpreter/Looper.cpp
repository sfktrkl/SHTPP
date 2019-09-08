#include "Interpreter.h"

const void Interpreter::Looper(size_t i, toks& tokens, vars& variables)
{
    int loopSeen = 0;
    bool loopStarted = false;
    bool isBody = false;
    toks loopTokens;
    toks conditionTokens;
    tok result;
    bool firstTime = true;

    while (i < tokens.size())
    {
        if (tokens[i].first == TokenType::KEYWORD && tokens[i].second == "LOOP" && !isBody && firstTime)
        {
            loopStarted = true;
            tokens.erase(tokens.begin() + i);
        }
        if (tokens[i].first == TokenType::KEYWORD && tokens[i].second == "LOOP" && isBody && firstTime)
        {
            loopSeen++;
            loopTokens.push_back(tokens[i]);
            tokens.erase(tokens.begin() + i);
        }
        else if (loopStarted
            && (tokens[i].first == TokenType::EXPRESSION || tokens[i].first == TokenType::NUMBER || tokens[i].first == TokenType::VARIABLE)
            && !isBody && firstTime)
        {
            result = CheckCondition(tokens[i], tokens[i + 2], tokens[i + 1], variables);
            conditionTokens.push_back(tokens[i]);
            tokens.erase(tokens.begin() + i);
            conditionTokens.push_back(tokens[i]);
            tokens.erase(tokens.begin() + i);
            conditionTokens.push_back(tokens[i]);
            tokens.erase(tokens.begin() + i);
        }
        else if (!loopStarted && tokens[i].first == TokenType::KEYWORD && tokens[i].second == "ENDLOOP"
            && isBody && loopSeen != 0 && firstTime)
        {
            loopSeen--;
            loopTokens.push_back(tokens[i]);
            tokens.erase(tokens.begin() + i);
        }
        else if (!loopStarted && tokens[i].first == TokenType::KEYWORD && tokens[i].second == "ENDLOOP"
            && isBody && loopSeen == 0 && firstTime)
        {
            isBody = false;
            firstTime = false;
            tokens.erase(tokens.begin() + i);
            if (result.first == TokenType::CONDITION && result.second == "TRUE")
                Parser(loopTokens, variables);
            else
                return;
            i--;
        }
        else if (((tokens[i].first == TokenType::KEYWORD && tokens[i].second == "THEN") || isBody) && firstTime)
        {
            if (!isBody)
            {
                loopStarted = false;
                isBody = true;
            }
            else
            {
                loopTokens.push_back(tokens[i]);
            }
            tokens.erase(tokens.begin() + i);
        }
        else if (!firstTime)
        {
            result = CheckCondition(conditionTokens[0], conditionTokens[2], conditionTokens[1], variables);
            if (result.first == TokenType::CONDITION && result.second == "TRUE")
                Parser(loopTokens, variables);
            else
                return;
        }
    }
}