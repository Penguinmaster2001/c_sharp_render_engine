
using RenderEngine.Scenes.Cameras;



namespace RenderEngine.Scenes;



internal interface IScene
{
    bool AddToScene(ISceneObject sceneObject);

    ISceneCamera? MainCamera { get; set; }



    void Render();

    void Delete();
}
