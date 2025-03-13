
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

using RenderEngine.Scenes;
using RenderEngine.Scenes.Cameras;



namespace RenderEngine.Windowing;



internal class Window : GameWindow
{
    internal (int Width, int Height) WindowSize { get; private set; }


    public IScene Scene { get; }

    public List<ISceneCamera> Cameras { get; }

    public ISceneCamera? MainCamera
    {
        get
        {
            if (_cameraIndex < 0) return null;

            return Cameras[_cameraIndex];
        }
    }
    private int _cameraIndex = -1;



    public Window(int width = 720, int height = 450) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
    {
        WindowSize = (width, height);

        CenterWindow(new Vector2i(WindowSize.Width, WindowSize.Height));

        Scene = new Scene();
        Cameras = [];
    }



    public void AddCamera(float fov, float clipNear, float clipFar)
    {
        PerspectiveCamera camera = new(fov, WindowSize.Width, WindowSize.Height, clipNear, clipFar);

        Cameras.Add(camera);

        if (_cameraIndex < 0)
        {
            _cameraIndex = 1;
            ChooseCamera(_cameraIndex);
        }
    }



    public void ChooseCamera(int camera)
    {
        if (camera < 0 || Cameras.Count < camera) return;

        _cameraIndex = camera;

        Scene.MainCamera = Cameras[_cameraIndex];
    }




    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);

        WindowSize = (e.Width, e.Height);

        foreach (ICamera camera in Cameras)
        {
            camera.ViewWidth = WindowSize.Width;
            camera.ViewHeight = WindowSize.Height;
        }

        GL.Viewport(0, 0, WindowSize.Width, WindowSize.Height);
    }



    protected override void OnLoad()
    {
        base.OnLoad();

        GL.Enable(EnableCap.DepthTest);
        GL.FrontFace(FrontFaceDirection.Cw);
        GL.Enable(EnableCap.CullFace);
        GL.CullFace(TriangleFace.Back);
    }



    protected override void OnUnload()
    {
        base.OnUnload();

        Scene.Delete();
    }



    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        FrameState frameState = new(args.Time, MouseState, KeyboardState);

        if (frameState.KeyboardState.IsKeyReleased(Keys.Escape))
        {
            CursorState = CursorState == CursorState.Grabbed ? CursorState.Normal : CursorState.Grabbed;
        }
    }



    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.ClearColor(0.0627f, 0.0666f, 0.1019f, 1.0f);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        Scene.Render();

        Context.SwapBuffers();
    }
}
