#pragma once
#include <Windows.h>
#include <process.h>

#include <osg/Geode>
#include <osg/Group>
#include <osg/ShapeDrawable>
#include <osg/Camera>
#include <osg/MatrixTransform>
#include <osgDB/ReadFile>
#include <osgText/Font3D>
#include <osgText/Text3D>
#include <osg/LightSource>
#include <osgGA/TrackballManipulator>
#include <osgViewer/Viewer>
#include <osgViewer/api/Win32/GraphicsWindowWin32>

class OSGView
{
public:
    void Render(HWND hwnd);
    void Destroy();

    void SetMission(int mission);

private:
    bool CreateViewer(HWND hwnd);
    osg::Geode* LoadMission();
    osg::Geode* LoadTutorial1();

    osg::ref_ptr<osg::Group> root;

    int missionNumber = 0;
};