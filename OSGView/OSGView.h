#pragma once
#include <Windows.h>
#include <process.h>

#include <osg/Geode>
#include <osg/Group>
#include <osg/ShapeDrawable>
#include <osg/Camera>
#include <osg/LightSource>
#include <osgGA/TrackballManipulator>
#include <osgViewer/Viewer>
#include <osgViewer/api/Win32/GraphicsWindowWin32>

class OSGView
{
public:
    bool CreateViewer(HWND hwnd);
    void Render(HWND hwnd);
    void Destroy();

    void CreateCube();
    void CreateSphere();

private:
    osg::ref_ptr<osg::Group> root;
};
