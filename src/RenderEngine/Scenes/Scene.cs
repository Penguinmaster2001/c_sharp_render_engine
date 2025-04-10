
using RenderEngine.Scenes.Cameras;
using RenderEngine.Scenes.Renderables;
using RenderEngine.OpenGLRendering;
using RenderEngine.Windowing;



namespace RenderEngine.Scenes;



internal class Scene : IScene
{
    private readonly List<ISceneObject> _sceneObjects = [];
    private readonly List<IRenderObject> _renderObjects = [];
    private readonly Renderer _renderer;
    public ISceneCamera? MainCamera { get; set; }



    public Scene()
    {
        _renderer = new();
    }


    public bool AddToScene(ISceneObject sceneObject)
    {
        _sceneObjects.Add(sceneObject);

        if (sceneObject is IRenderObject renderObject)
        {
            _renderObjects.Add(renderObject);
        }

        sceneObject.AddToScene(this);

        return true;
    }



    public void Update(FrameState frameState)
    {
        foreach (ISceneObject sceneObject in _sceneObjects)
        {
            sceneObject.Update(frameState);
        }
    }



    public void Render()
    {
        if (MainCamera is null) return;

        _renderer.Render(MainCamera, _renderObjects);
    }



    public void Delete()
    {
        foreach (IRenderObject renderObject in _renderObjects)
        {
            renderObject.Delete();
        }
    }
}
