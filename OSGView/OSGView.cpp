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

bool OSGView::CreateViewer(HWND hwnd)
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

    camera->setDrawBuffer(GL_BACK);
    camera->setReadBuffer(GL_BACK);

    root = new osg::Group();
    // turn off light
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
    if (CreateViewer(hwnd))
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
    else
        return nullptr;
}

osg::ref_ptr<osgText::Font3D> g_font3D = osgText::readFont3DFile("fonts/arial.ttf");

osgText::Text3D* createText3D(const osg::Vec3& pos, const std::string& content, float size, float depth)
{
    osg::ref_ptr<osgText::Text3D> text = new osgText::Text3D;
    text->setFont(g_font3D.get());
    text->setCharacterSize(size);
    text->setCharacterDepth(depth);
    text->setAxisAlignment(osgText::TextBase::XZ_PLANE);
    text->setPosition(pos);
    text->setText(content);
    return text.release();
}

osg::Geode* OSGView::LoadTutorial1()
{
    // creage geode and add cubedrawable
    osg::ref_ptr<osg::Geode> geode(new osg::Geode());
    geode->addDrawable(createText3D(osg::Vec3(), " 3 + 2 = ?", 20.0f, 10.0f));

    return geode.release();
}
