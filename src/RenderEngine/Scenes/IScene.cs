
using RenderEngine.Scenes.Cameras;
using RenderEngine.Windowing;



namespace RenderEngine.Scenes;



public interface IScene
{
    bool AddToScene(ISceneObject sceneObject);

    ISceneCamera? MainCamera { get; set; }



    void Render();

    void Update(FrameState frameState);

    void Delete();
}
