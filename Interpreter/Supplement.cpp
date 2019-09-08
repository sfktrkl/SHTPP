#include "Interpreter.h"

void Interpreter::AddDebugOutput(std::string text, bool error, bool isShoot)
{
    if (error)
        debugOutputs.push_back("-----------------------------------------------------\n");

    if (isShoot)
        debugOutputs.push_back("SHOOT: " + text);
    else
        debugOutputs.push_back("DEBUG: " + text);
}

void Interpreter::AddOutput(std::string text)
{
    outputs.push_back(std::stoi(text));
}

const std::string Interpreter::OpenFile(const char* filename)
{
    std::ifstream file(filename);
    std::string str((std::istreambuf_iterator<char>(file)), std::istreambuf_iterator<char>());
    str += "<EOF>";

    return str;
}

const tok Interpreter::CheckCondition(tok& leftOperand, tok& rightOperand, tok& operatorTok, vars& variables)
{
    std::string first, second;
    if (leftOperand.first == TokenType::EXPRESSION)
        first = EvaluateExpression(leftOperand.second, variables);
    else if (leftOperand.first == TokenType::NUMBER)
        first = leftOperand.second;
    else if (leftOperand.first == TokenType::VARIABLE)
        first = variables[leftOperand.second].getValue();

    if (rightOperand.first == TokenType::EXPRESSION)
        second = EvaluateExpression(rightOperand.second, variables);
    else if (rightOperand.first == TokenType::NUMBER)
        second = rightOperand.second;
    else if (rightOperand.first == TokenType::VARIABLE)
        second = variables[rightOperand.second].getValue();

    tok trueTok = std::make_pair(TokenType::CONDITION, "TRUE");
    tok falseTok = std::make_pair(TokenType::CONDITION, "FALSE");

    if (operatorTok.first == TokenType::EQUAL_TO)
    {
        if (std::stoi(first) == std::stoi(second))
            return trueTok;
        else
            return falseTok;
    }
    if (operatorTok.first == TokenType::NOT_EQUAL_TO)
    {
        if (std::stoi(first) != std::stoi(second))
            return trueTok;
        else
            return falseTok;
    }
    else if (operatorTok.first == TokenType::GREATER)
    {
        if (std::stoi(first) > std::stoi(second))
            return trueTok;
        else
            return falseTok;
    }
    else if (operatorTok.first == TokenType::LESS)
    {
        if (std::stoi(first) < std::stoi(second))
            return trueTok;
        else
            return falseTok;
    }
    else if (operatorTok.first == TokenType::GREATER_OR_EQUAL)
    {
        if (std::stoi(first) >= std::stoi(second))
            return trueTok;
        else
            return falseTok;
    }
    else if (operatorTok.first == TokenType::LESS_OR_EQUAL)
    {
        if (std::stoi(first) <= std::stoi(second))
            return trueTok;
        else
            return falseTok;
    }
    else
    {
        AddDebugOutput("SOZ DIZIMI HATASI: OPERATOR BULUNAMADI!", true);
        return falseTok;
    }
}

const std::string Interpreter::EvaluateExpression(std::string expression, vars& variables)
{
    expression += "q";
    int result{};
    int numberPosition{};
    std::vector<int> numberStack;
    std::vector<std::pair<char, std::vector<int>>> operatorStack;
    bool variableStarted = false;
    std::string variableName;
    std::string number;

    for (char& ch : expression) {
        if (ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '%')
        {
            numberStack.push_back(std::stoi(number));
            number = "";
            std::vector<int> temp = { numberPosition, numberPosition + 1 };
            operatorStack.push_back(std::make_pair(ch, temp));
            numberPosition++;
        }
        else if (ch == 'q')
        {
            numberStack.push_back(std::stoi(number));
            number = "";
        }
        else if (ch == '$')
        {
            if (variableStarted == false)
                variableStarted = true;
            else
            {
                number = variables[number].getValue();
                variableStarted = false;
            }
        }
        else
        {
            number += ch;
        }
    }

    // Associativity left to right
    auto calculate = [&](char operaTor)
    {
        if (numberStack.size() != 1 && operatorStack.size() != 0)
        {
            for (auto& op : operatorStack)
            {
                if (op.first == operaTor)
                {
                    switch (operaTor)
                    {
                    case '*':
                        result = numberStack[op.second[0]] * numberStack[op.second[1]];
                        break;
                    case '/':
                        if (numberStack[op.second[1]] == 0)
                            throw "IFADE HATASI: 0'A BOLME ISLEMI YAPILAMAZ!";
                        result = numberStack[op.second[0]] / numberStack[op.second[1]];
                        break;
                    case '%':
                        result = numberStack[op.second[0]] % numberStack[op.second[1]];
                        break;
                    case '+':
                        result = numberStack[op.second[0]] + numberStack[op.second[1]];
                        break;
                    case '-':
                        result = numberStack[op.second[0]] - numberStack[op.second[1]];
                        break;
                    }

                    numberStack[op.second[0]] = result;
                    numberStack.erase(numberStack.begin() + op.second[1]);

                    for (auto& ope : operatorStack)
                    {
                        if (ope.second[0] >= op.second[1])
                            ope.second[0]--;
                        if (ope.second[1] >= op.second[1])
                            ope.second[1]--;
                    }
                }
            }
        }
    };

    // Precedence
    calculate('*');
    calculate('/');
    calculate('%');
    calculate('+');
    calculate('-');

    return std::to_string(result);
}

const bool Interpreter::checkKey(const vars& variables, const std::string key)
{
    if (variables.find(key) == variables.end())
        return false;

    return true;
}

const std::pair<VariableType, std::string> Interpreter::Scan(vars& variables)
{
    std::pair<VariableType, std::string> data;
    std::string input;
    input = std::to_string(inputs[inputNumber]);
    inputNumber++;
    toks tokens;
    Lexer(input + "\n", tokens);

    if (tokens.size() != 0)
    {
        if (tokens[0].first == TokenType::STRING)
        {
            data.first = VariableType::STRING;
            data.second = tokens[0].second;
        }
        else if (tokens[0].first == TokenType::NUMBER)
        {
            data.first = VariableType::NUMBER;
            data.second = tokens[0].second;
        }
        else if (tokens[0].first == TokenType::EXPRESSION)
        {
            data.first = VariableType::NUMBER;
            data.second = EvaluateExpression(tokens[0].second, variables);
        }
    }
    else
    {
        data.first = VariableType::STRING;
        data.second = input;
    }

    return data;
}