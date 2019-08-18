#pragma once
#include "Required.h"
#include "Variable.h"

typedef std::vector<std::pair<TokenType, std::string>> toks;
typedef std::unordered_map<std::string, Variable> vars;

class Interpreter
{
public:
    Interpreter(const char* file)
    {
        std::string fileContents = OpenFile(file);

        toks tokens;
        vars variables;

        Lexer(fileContents, tokens);
        Parser(tokens, variables);
    }

    void Print(std::string text, bool error = false);
    const std::string OpenFile(const char* filename);
    const std::string EvaluateExpression(std::string expression);
    const void Lexer(const std::string& fileContents, toks& tokens);
    const void Conditioner(toks& tokens, std::vector<toks>& ifTokens);
    const void Parser(toks& tokens, vars& variables);
    const bool checkKey(const vars& variables, const std::string key);
    const std::pair<VariableType, std::string> Scan();
};
