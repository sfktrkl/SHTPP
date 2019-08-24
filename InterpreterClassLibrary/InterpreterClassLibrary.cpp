#include "stdafx.h"

#include "InterpreterClassLibrary.h"

using namespace InterpreterClassLibrary;

InterpreterClassWrapper::InterpreterClassWrapper(const char* file)
{
    interpreter = new Interpreter(file);
}

array<double>^ InterpreterClassWrapper::TakeOutputs()
{
    std::vector<double> outputs =  interpreter->GiveOutputs();

    auto result = gcnew array<double>((int)outputs.size());

    for (int i = 0; i < outputs.size(); ++i)
        result[i] = outputs[i];

    return result;
}
