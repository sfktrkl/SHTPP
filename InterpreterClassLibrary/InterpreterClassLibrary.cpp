#include "stdafx.h"

#include "InterpreterClassLibrary.h"

using namespace InterpreterClassLibrary;

InterpreterClassWrapper::InterpreterClassWrapper(const char* file)
{
    interpreter = new Interpreter(file);
}
