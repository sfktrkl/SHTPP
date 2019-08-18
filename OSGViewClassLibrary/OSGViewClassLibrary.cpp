#include "stdafx.h"

#include "OSGViewClassLibrary.h"

using namespace OSGViewClassLibrary;

OSGViewClassWrapper::OSGViewClassWrapper()
{
    osgView = new OSGView();
}

void OSGViewClassWrapper::CreateCube() {
    osgView->CreateCube();
}

void OSGViewClassWrapper::CreateSphere() {
    osgView->CreateSphere();
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