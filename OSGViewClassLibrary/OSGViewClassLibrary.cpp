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

void OSGViewClassWrapper::GiveOutputs(double* outputs)
{
    std::vector<double> results(outputs, outputs + sizeof outputs / sizeof outputs[0]);

    osgView->TakeOutputs(results);
}

void OSGViewClassWrapper::SetSuccess(bool success)
{
    osgView->SetSuccess(success);
}

