
using RenderEngine.Scenes.Cameras;

namespace RenderEngine.Scenes;



internal interface IScene
{
    bool AddToScene(ISceneObject sceneObject);

    ICamera? MainCamera { get; set; }



    void Render();
}
