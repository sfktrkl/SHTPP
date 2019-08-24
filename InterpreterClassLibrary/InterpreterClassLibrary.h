#pragma once
#include "../Interpreter/Interpreter.h"
#include "../Interpreter/Conditioner.cpp"
#include "../Interpreter/Parser.cpp"
#include "../Interpreter/Lexer.cpp"
#include "../Interpreter/Supplement.cpp"
using namespace System;

namespace InterpreterClassLibrary {
	public ref class InterpreterClassWrapper
	{
    public:
        InterpreterClassWrapper(const char* file);

        array<int>^ TakeOutputs();
    private:
        Interpreter* interpreter;
	};
}
