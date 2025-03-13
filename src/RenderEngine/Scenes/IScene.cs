
using RenderEngine.Scenes.Cameras;



namespace RenderEngine.Scenes;



public interface IScene
{
    bool AddToScene(ISceneObject sceneObject);

    ISceneCamera? MainCamera { get; set; }



    void Render();

    void Delete();
}
