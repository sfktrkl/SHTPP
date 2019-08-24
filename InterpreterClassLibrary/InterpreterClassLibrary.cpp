#include "stdafx.h"

#include "InterpreterClassLibrary.h"

using namespace InterpreterClassLibrary;

InterpreterClassWrapper::InterpreterClassWrapper(const char* file)
{
    interpreter = new Interpreter(file);
}

array<int>^ InterpreterClassWrapper::TakeOutputs()
{
    std::vector<int> outputs =  interpreter->GiveOutputs();

    auto result = gcnew array<int>((int)outputs.size());

    for (int i = 0; i < outputs.size(); ++i)
        result[i] = outputs[i];

    return result;
}
