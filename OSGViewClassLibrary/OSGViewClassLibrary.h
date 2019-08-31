#pragma once
#include <Windows.h>
#include "../OSGView/OSGView.h"
#include "../OSGView/OSGView.cpp"
using namespace System;

namespace OSGViewClassLibrary {
    public ref class OSGViewClassWrapper
    {
    public:
        OSGViewClassWrapper();

        void Render(IntPtr hwnd);
        void Destroy();
        void Refresh();

        void SetMission(int mission);

        void GiveOutputs(int* outputs);
        void GiveInputs(int* inputs);
        void SetSuccess(bool success);
    private:
        OSGView* osgView; // an instance of class in C++
    };
}