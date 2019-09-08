#pragma once
#include "../Interpreter/Interpreter.h"
#include "../Interpreter/Conditioner.cpp"
#include "../Interpreter/Parser.cpp"
#include "../Interpreter/Lexer.cpp"
#include "../Interpreter/Supplement.cpp"
#include "../Interpreter/Looper.cpp"
using namespace System;

namespace InterpreterClassLibrary {
    public ref class InterpreterClassWrapper
    {
    public:
        InterpreterClassWrapper(String^ file);
        void Execute();

        array<int>^ TakeOutputs();
        array<String^>^ TakeDebugOutputs();
        void GiveInputs(array<int>^ inputs);
        void SetDebugMode(bool isDebugShoot);
    private:
        Interpreter* interpreter;
    };
}
