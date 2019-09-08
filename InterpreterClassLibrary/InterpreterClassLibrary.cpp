#include "stdafx.h"

#include "InterpreterClassLibrary.h"

using namespace InterpreterClassLibrary;

InterpreterClassWrapper::InterpreterClassWrapper(String^ file)
{
    char* fileName = new char[file->Length];
    int i;
    for (i = 0; i < file->Length; i++)
        fileName[i] = file[i];
    fileName[i] = static_cast<char>('\0');
    interpreter = new Interpreter(fileName);
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

void InterpreterClassWrapper::GiveInputs(array<int>^ inputs)
{
    std::vector<int> inputsVector;

    for (int i = 0; i < inputs->Length; i++)
    {
        int value = inputs[i];
        inputsVector.push_back(value);
    }

    interpreter->TakeInputs(inputsVector);
}

void InterpreterClassWrapper::SetDebugMode(bool isDebugShoot)
{
    interpreter->SetDebugMode(isDebugShoot);
}