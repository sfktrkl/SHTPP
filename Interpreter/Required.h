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
    NOT,
    EQUAL_TO,
    NOT_EQUAL_TO,
    LESS,
    GREATER,
    LESS_OR_EQUAL,
    GREATER_OR_EQUAL,
    STATEMENT,
    CONDITION,
    LOOP
};

enum class VariableType
{
    NONE,
    STRING,
    NUMBER
};