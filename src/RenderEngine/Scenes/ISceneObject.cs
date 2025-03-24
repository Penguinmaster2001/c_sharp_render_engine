
using OpenTK.Mathematics;
using RenderEngine.Windowing;



namespace RenderEngine.Scenes;



public interface ISceneObject
{
    IScene? Scene { get; }
    Matrix4 Transform { get; }


    void Update(FrameState frameState);


    void AddToScene(IScene scene);
}
