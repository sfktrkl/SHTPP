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

void OSGViewClassWrapper::GiveOutputs(int* outputs)
{
    std::vector<int> outputsVector(outputs, outputs + sizeof outputs / sizeof outputs[0]);

    osgView->TakeOutputs(outputsVector);
}

void OSGViewClassWrapper::GiveInputs(int* inputs)
{
    std::vector<int> inputsVector(inputs, inputs + sizeof inputs / sizeof inputs[0]);

    osgView->TakeInputs(inputsVector);
}

void OSGViewClassWrapper::SetSuccess(bool success)
{
    osgView->SetSuccess(success);
}

