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
    void Refresh();

    void SetMission(int mission);

    void TakeOutputs(std::vector<int> results);
    void SetSuccess(bool success);

private:
    HWND hwnd;
    bool CreateViewer();
    osg::Geode* LoadMission();
    osg::Geode* LoadTutorial1();

    osg::ref_ptr<osg::Group> root;

    int missionNumber = 0;

    std::vector<int> solutions;

    osgText::Text3D* Success();
    bool success = false;


};