#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <list>
#include <unordered_map>

enum class TokenType
{
    KEYWORD,
    STRING,
    NUMBER,
    EXPRESSION,
    VARIABLE,
    EQUALS,
    EQEQ,
    STATEMENT,
    CONDITION
};

enum class VariableType
{
    NONE,
    STRING,
    NUMBER
};