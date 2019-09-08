#include "stdafx.h"

#include <vector>
#include "OSGViewClassLibrary.h"

using namespace OSGViewClassLibrary;

OSGViewClassWrapper::OSGViewClassWrapper()
{
    osgView = new OSGView();
}

void OSGViewClassWrapper::Render(IntPtr hwnd)
{
    // Get the pointer as window handler
    HWND nativeHWND = (HWND)hwnd.ToPointer();

    // Call the native Render method
    osgView->Render(nativeHWND);
}

void OSGViewClassWrapper::Destroy()
{
    // Call the native Destroy method
    osgView->Destroy();
}

void OSGViewClassWrapper::Refresh()
{
    // Call the native Destroy method
    osgView->Refresh();
}

void OSGViewClassWrapper::SetMission(int mission)
{
    // Call the native Destroy method
    osgView->SetMission(mission);
}

void OSGViewClassWrapper::GiveOutputs(array<int>^ outputs)
{
    std::vector<int> outputsVector;

    for (size_t i = 0; i < outputs->Length; i++)
    {
        int value = outputs[i];
        outputsVector.push_back(value);
    }

    osgView->TakeOutputs(outputsVector);
}

void OSGViewClassWrapper::GiveInputs(array<int>^ inputs)
{
    std::vector<int> inputsVector;

    for (size_t i = 0; i < inputs->Length; i++)
    {
        int value = inputs[i];
        inputsVector.push_back(value);
    }

    osgView->TakeInputs(inputsVector);
}

void OSGViewClassWrapper::SetSuccess(bool success)
{
    osgView->SetSuccess(success);
}