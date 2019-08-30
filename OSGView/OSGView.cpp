#pragma once
#include "OSGView.h"

osg::ref_ptr<osgViewer::Viewer> viewer;
bool finished;

static void RenderingThread(void*)
{
    // Keep the rendering as long as the viewer's work isn't done
    while (!viewer->done())
    {
        viewer->frame();
    }

    // The rendering is done, set the status to Finished
    finished = true;
}

osg::ref_ptr<osgText::Font3D> g_font3D = osgText::readFont3DFile("fonts/arial.ttf");

osgText::Text3D* createText3D(const osg::Vec3& pos, const std::string& content, float size, float depth, osg::Vec4 color = osg::Vec4(0.5f, 0.5, 0.5, 1.0f))
{
    osg::ref_ptr<osgText::Text3D> text = new osgText::Text3D;
    text->setFont(g_font3D.get());
    text->setCharacterSize(size);
    text->setCharacterDepth(depth);
    text->setAxisAlignment(osgText::TextBase::XZ_PLANE);
    text->setPosition(pos);
    text->setText(content);
    text->setColor(color);
    return text.release();
}

bool OSGView::CreateViewer()
{
    // Get the dimensions of the window handle
    RECT rect;
    GetWindowRect(hwnd, &rect);

    // WindowData is used to pass in the Win32 window handle attached the GraphicsContext::Traits structure
    osg::ref_ptr<osg::Referenced> windata(new osgViewer::GraphicsWindowWin32::WindowData(hwnd));

    // Create osg's graphics context traits
    osg::ref_ptr<osg::GraphicsContext::Traits> traits = new osg::GraphicsContext::Traits;

    // Set location and size of the window
    traits->x = 0;
    traits->y = 0;
    traits->width = rect.right - rect.left;
    traits->height = rect.bottom - rect.top;
    traits->windowDecoration = false;
    traits->doubleBuffer = true;
    traits->sharedContext = 0;
    traits->inheritedWindowData = windata;
    traits->pbuffer = false;

    //// Create graphics context
    osg::ref_ptr<osg::GraphicsContext> gc = osg::GraphicsContext::createGraphicsContext(traits.get());
    osg::ref_ptr<osg::Camera> camera = new osg::Camera;
    camera->setGraphicsContext(gc.get());
    camera->setViewport(new osg::Viewport(0, 0, traits->width, traits->height));
    camera->setClearMask(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    camera->setDrawBuffer(GL_BACK);
    camera->setReadBuffer(GL_BACK);

    root = new osg::Group();
    root->getOrCreateStateSet()->setMode(GL_LIGHTING, osg::StateAttribute::ON);
    root->getOrCreateStateSet()->setMode(GL_DEPTH_TEST, osg::StateAttribute::ON);
    root->addChild(LoadMission());

    // Create the viewer and attach the camera to it
    viewer = new osgViewer::Viewer;
    viewer->addSlave(camera.get());
    viewer->setCamera(camera.get());
    viewer->setSceneData(root);
    viewer->setKeyEventSetsDone(0);
    viewer->setCameraManipulator(new osgGA::TrackballManipulator);

    // The viewer isn't rendering yet, set the status to False
    finished = false;

    return true;
}

void OSGView::Render(HWND hwnd)
{
    this->hwnd = hwnd;

    if (CreateViewer())
    {
        // Create a rendering thread
        _beginthread(RenderingThread, 0, NULL);
    }
}

void OSGView::Destroy()
{
    // Set viewer's work to Done
    viewer->setDone(true);

    // Get the rendering status
    while (!finished) Sleep(10);

    // Release the memory
    viewer = NULL;
    finished = NULL;
    root = NULL;
}

void OSGView::Refresh()
{
    // Set viewer's work to Done
    viewer->setDone(true);

    // Get the rendering status
    while (!finished) Sleep(10);

    // Release the memory
    viewer = NULL;
    finished = NULL;
    root = NULL;

    Render(hwnd);
}

void OSGView::SetMission(int mission)
{
    this->missionNumber = mission;
}

osg::Geode* OSGView::LoadMission()
{
    if (missionNumber == 0)
        return nullptr;
    else if (missionNumber == 1)
        return LoadTutorial1();
    else if (missionNumber == 2)
        return LoadTutorial2();
    else if (missionNumber == 3)
        return LoadTutorial3();
    else if (missionNumber == 4)
        return LoadTutorial4();
    else
        return nullptr;
}

void OSGView::TakeOutputs(std::vector<int> results)
{
    this->solutions = results;
}

void OSGView::TakeInputs(std::vector<int> inputs)
{
    this->inputs = inputs;
}

void OSGView::SetSuccess(bool success)
{
    this->success = success;
}

osgText::Text3D* OSGView::Success()
{
    osg::ref_ptr<osgText::Text3D> drawable;

    if (success)
        drawable = createText3D(osg::Vec3(0.0f, 0.0f, -50.0f), "Success", 10.0f, 10.0f, osg::Vec4(0.0f, 1.0f, 0.0f, 1.0f));
    else
        drawable = createText3D(osg::Vec3(0.0f, 0.0f, -50.0f), "Fail", 10.0f, 10.0f, osg::Vec4(1.0f, 0.0f, 0.0f, 1.0f));

    return drawable.release();
}

osg::Geode* OSGView::LoadTutorial1()
{
    // Create geode
    osg::ref_ptr<osg::Geode> geode(new osg::Geode());

    if (solutions.size() == 0)
    {
        geode->addDrawable(createText3D(osg::Vec3(), " 3 + 2 = ?", 20.0f, 10.0f));
    }
    else
    {
        geode->addDrawable(createText3D(osg::Vec3(), " 3 + 2 = " + std::to_string(solutions[0]), 20.0f, 10.0f));
        geode->addDrawable(Success());
    }

    return geode.release();
}

osg::Geode* OSGView::LoadTutorial2()
{
    // Create geode
    osg::ref_ptr<osg::Geode> geode(new osg::Geode());

    if (solutions.size() == 0)
    {
        geode->addDrawable(createText3D(osg::Vec3(), " 3 + 2 = FIRST", 10.0f, 10.0f));
        geode->addDrawable(createText3D(osg::Vec3(0.0f, 0.0f, -20.0f), " 7 + 8 = SECOND", 10.0f, 10.0f));
        geode->addDrawable(createText3D(osg::Vec3(0.0f, 0.0f, -40.0f), " FIRST + SECOND = ???", 10.0f, 10.0f));
    }
    else
    {
        geode->addDrawable(createText3D(osg::Vec3(), " 3 + 2 = FIRST", 10.0f, 10.0f));
        geode->addDrawable(createText3D(osg::Vec3(0.0f, 0.0f, -15.0f), " 7 + 8 = SECOND", 10.0f, 10.0f));
        geode->addDrawable(createText3D(osg::Vec3(0.0f, 0.0f, -30.0f), " FIRST + SECOND = " + std::to_string(solutions[0]), 10.0f, 10.0f));
        geode->addDrawable(Success());
    }

    return geode.release();
}

osg::Geode* OSGView::LoadTutorial3()
{
    // Create geode
    osg::ref_ptr<osg::Geode> geode(new osg::Geode());

    if (solutions.size() == 0 && inputs.size() != 0)
    {
        geode->addDrawable(createText3D(osg::Vec3(), "??? + 3 = ?", 20.0f, 10.0f));
    }
    else
    {
        geode->addDrawable(createText3D(osg::Vec3(), std::to_string(inputs[0]) + " + 3 = " + std::to_string(solutions[0]), 20.0f, 10.0f));
        geode->addDrawable(Success());
    }

    return geode.release();
}

osg::Geode* OSGView::LoadTutorial4()
{
    // Create geode
    osg::ref_ptr<osg::Geode> geode(new osg::Geode());

    if (solutions.size() == 0 && inputs.size() != 0)
    {
        geode->addDrawable(createText3D(osg::Vec3(), "??? >> ODD(1) OR EVEN(0)", 20.0f, 10.0f));
    }
    else
    {
        std::string solution;
        if (solutions[0] == 1)
            solution = "ODD";
        else
            solution = "EVEN";

        geode->addDrawable(createText3D(osg::Vec3(), std::to_string(inputs[0]) + " >> " + solution, 20.0f, 10.0f));
        geode->addDrawable(Success());
    }

    return geode.release();
}

