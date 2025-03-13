
using OpenTK.Mathematics;
using RenderEngine.Windowing;



namespace RenderEngine.Scenes;



public interface ISceneObject
{
    Matrix4 Transform { get; }


    void Update(FrameState frameState);
}
