#pragma once
#include "Required.h"
#include "Interpreter.h"

class Variable
{
private:
    VariableType variableType;
    std::string value;
public:
    Variable() : value(""), variableType(VariableType::NONE) {}
    Variable(VariableType type, std::string data) : value(data), variableType(type) {}
    ~Variable() {}

    void setData(VariableType type, std::string data) { this->variableType = type; this->value = data; }
    std::string getValue() const { return this->value; }
    VariableType getType() const { return this->variableType; }
};
