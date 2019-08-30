#pragma once
#include "Required.h"
#include "Variable.h"

typedef std::vector<std::pair<TokenType, std::string>> toks;
typedef std::unordered_map<std::string, Variable> vars;
typedef std::vector<std::tuple<toks, toks>> iftoks;

class Interpreter
{
public:
    Interpreter(const char* file)
    {
        this->fileContents = OpenFile(file);
    }

    void Execute()
    {
        toks tokens;
        vars variables;

        Lexer(fileContents, tokens);
        Parser(tokens, variables);
    }

    std::vector<int> GiveOutputs() { return outputs; }
    void TakeInputs(std::vector<int> inputs) { this->inputs = inputs; inputNumber = 0; }

private:
    void AddOutput(std::string text, bool error = false);
    const std::string OpenFile(const char* filename);
    const std::string EvaluateExpression(std::string expression, vars& variables);
    const void Lexer(const std::string& fileContents, toks& tokens);
    const void Conditioner(size_t i, toks& tokens, iftoks& ifTokens, vars& variables);
    const void Parser(toks& tokens, vars& variables);
    const bool checkKey(const vars& variables, const std::string key);
    const std::pair<VariableType, std::string> Scan(vars& variables);

    size_t conditionNumber = 0;

    std::string fileContents;

    std::vector<int> outputs;
    std::vector<int> inputs;
    int inputNumber{ };
};
