#include "stdafx.h"

#include "InterpreterClassLibrary.h"

using namespace InterpreterClassLibrary;

InterpreterClassWrapper::InterpreterClassWrapper(const char* file)
{
    interpreter = new Interpreter(file);
}

void InterpreterClassWrapper::Execute()
{
    interpreter->Execute();
}

array<int>^ InterpreterClassWrapper::TakeOutputs()
{
    std::vector<int> outputs = interpreter->GiveOutputs();

    auto result = gcnew array<int>((int)outputs.size());

    for (int i = 0; i < outputs.size(); ++i)
        result[i] = outputs[i];

    return result;
}

array<String^>^ InterpreterClassWrapper::TakeDebugOutputs()
{
    std::vector<std::string> debugOutputs = interpreter->GiveDebugOutputs();

    auto result = gcnew array<String^>((int)debugOutputs.size());

    for (int i = 0; i < debugOutputs.size(); i++)
        result[i] = gcnew String(debugOutputs[i].c_str());

    return result;
}

void InterpreterClassWrapper::GiveInputs(int* inputs)
{
    std::vector<int> inputsVector(inputs, inputs + sizeof inputs / sizeof inputs[0]);

    interpreter->TakeInputs(inputsVector);
}

void InterpreterClassWrapper::SetDebugMode(bool isDebugShoot)
{
    interpreter->SetDebugMode(isDebugShoot);
}
