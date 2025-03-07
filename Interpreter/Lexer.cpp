#include "Interpreter.h"
#include <regex>

const void Interpreter::Lexer(const std::string& fileContents, toks& tokens)
{
    std::string token = "";
    bool state = false;
    std::string text = "";
    std::string expression = "";
    std::string number = "";
    bool isExpression = false;
    bool variableStarted = false;
    std::string variable = "";
    bool isComment = false;

    std::regex numbers("[0-9]");
    std::regex operators("(\\+|\\*|\\-|\\/|\\%)");

    for (char ch : fileContents)
    {
        token += ch;
        if (token == " ")
        {
            if (state == false)
                token = "";
            else
            {
                text += token;
                token = "";
            }
        }
        else if (token == "#")
        {
            isComment = true;
            token = "";
        }
        else if (token == "\n" || token == "<EOF>")
        {
            if (expression != "" && isExpression == true && variable != "")
            {
                expression = expression + "$" + variable + "$";
                tokens.push_back(std::make_pair(TokenType::EXPRESSION, expression));
                expression = "";
                variable = "";
                isExpression = false;
                variableStarted = false;
            }
            else if (expression != "" && isExpression == true)
            {
                tokens.push_back(std::make_pair(TokenType::EXPRESSION, expression));
                expression = "";
                isExpression = false;
            }
            else if (expression != "" && isExpression == false)
            {
                tokens.push_back(std::make_pair(TokenType::NUMBER, expression));
                expression = "";
            }
            else if (variable != "")
            {
                tokens.push_back(std::make_pair(TokenType::VARIABLE, variable));
                variable = "";
                variableStarted = false;
            }
            if (token == "<EOF>")
                return;

            isComment = false;
            token = "";
        }
        else if (isComment)
        {
            token = "";
        }
        else if (token == "=" && state == false)
        {
            if (variable != "" && variableStarted == true)
            {
                tokens.push_back(std::make_pair(TokenType::VARIABLE, variable));
                tokens.push_back(std::make_pair(TokenType::EQUALS, ""));
                variable = "";
                variableStarted = false;
            }
            else if (expression != "" && isExpression == true)
            {
                tokens.push_back(std::make_pair(TokenType::EXPRESSION, expression));
                tokens.push_back(std::make_pair(TokenType::EQUALS, ""));
                expression = "";
                isExpression = false;
            }
            else if (expression != "" && isExpression == false)
            {
                tokens.push_back(std::make_pair(TokenType::NUMBER, expression));
                tokens.push_back(std::make_pair(TokenType::EQUALS, ""));
                expression = "";
            }
            else if (tokens.back().first == TokenType::EQUALS)
                tokens.back().first = TokenType::EQUAL_TO;
            else if (tokens.back().first == TokenType::NOT)
                tokens.back().first = TokenType::NOT_EQUAL_TO;
            else if (tokens.back().first == TokenType::GREATER)
                tokens.back().first = TokenType::GREATER_OR_EQUAL;
            else if (tokens.back().first == TokenType::LESS)
                tokens.back().first = TokenType::LESS_OR_EQUAL;
            token = "";
        }
        else if (token == "<" && state == false)
        {
            if (variable != "" && variableStarted == true)
            {
                tokens.push_back(std::make_pair(TokenType::VARIABLE, variable));
                tokens.push_back(std::make_pair(TokenType::LESS, ""));
                variable = "";
                variableStarted = false;
            }
            else if (expression != "" && isExpression == true)
            {
                tokens.push_back(std::make_pair(TokenType::EXPRESSION, expression));
                tokens.push_back(std::make_pair(TokenType::LESS, ""));
                expression = "";
                isExpression = false;
            }
            else if (expression != "" && isExpression == false)
            {
                tokens.push_back(std::make_pair(TokenType::NUMBER, expression));
                tokens.push_back(std::make_pair(TokenType::LESS, ""));
                expression = "";
            }
            token = "";
        }
        else if (token == ">" && state == false)
        {
            if (variable != "" && variableStarted == true)
            {
                tokens.push_back(std::make_pair(TokenType::VARIABLE, variable));
                tokens.push_back(std::make_pair(TokenType::GREATER, ""));
                variable = "";
                variableStarted = false;
            }
            else if (expression != "" && isExpression == true)
            {
                tokens.push_back(std::make_pair(TokenType::EXPRESSION, expression));
                tokens.push_back(std::make_pair(TokenType::GREATER, ""));
                expression = "";
                isExpression = false;
            }
            else if (expression != "" && isExpression == false)
            {
                tokens.push_back(std::make_pair(TokenType::NUMBER, expression));
                tokens.push_back(std::make_pair(TokenType::GREATER, ""));
                expression = "";
            }
            token = "";
        }
        else if (token == "!" && state == false)
        {
            if (variable != "" && variableStarted == true)
            {
                tokens.push_back(std::make_pair(TokenType::VARIABLE, variable));
                tokens.push_back(std::make_pair(TokenType::NOT, ""));
                variable = "";
                variableStarted = false;
            }
            else if (expression != "" && isExpression == true)
            {
                tokens.push_back(std::make_pair(TokenType::EXPRESSION, expression));
                tokens.push_back(std::make_pair(TokenType::NOT, ""));
                expression = "";
                isExpression = false;
            }
            else if (expression != "" && isExpression == false)
            {
                tokens.push_back(std::make_pair(TokenType::NUMBER, expression));
                tokens.push_back(std::make_pair(TokenType::NOT, ""));
                expression = "";
            }
            token = "";
        }
        else if (token == "$" && state == false)
        {
            variableStarted = true;
            token = "";
        }
        else if (std::regex_match(token, operators))
        {
            isExpression = true;
            if (variable != "")
            {
                expression = expression + "$" + variable + "$" + token;
                variable = "";
                variableStarted = false;
            }
            else
                expression += token;

            token = "";
        }
        else if (variableStarted == true)
        {
            if (token == "<")
                variableStarted = false;
            else
            {
                variable += token;
                token = "";
            }
        }
        else if (token == "SHOOT")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (token == "DEBUG")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (token == "ENDIF")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (token == "ENDLOOP")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (token == "LOOP")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (token == "ELSE")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (token == "IF")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (token == "THEN")
        {
            if (expression != "" && isExpression == true)
            {
                tokens.push_back(std::make_pair(TokenType::EXPRESSION, expression));
                isExpression = false;
            }
            else if (expression != "" && isExpression == false)
                tokens.push_back(std::make_pair(TokenType::NUMBER, expression));
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            expression = "";
            token = "";
        }
        else if (token == "INPUT")
        {
            tokens.push_back(std::make_pair(TokenType::KEYWORD, token));
            token = "";
        }
        else if (std::regex_match(token, numbers))
        {
            expression += token;
            token = "";
        }
        else if (token == "\"")
        {
            if (state == false)
            {
                state = true;
                token = "";
            }
            else if (state == true)
            {
                tokens.push_back(std::make_pair(TokenType::STRING, text));
                text = "";
                state = false;
                token = "";
            }
        }
        else if (token == "\t")
        {
            token = "";
        }
        else if (state == true)
        {
            text += token;
            token = "";
        }
    }
}