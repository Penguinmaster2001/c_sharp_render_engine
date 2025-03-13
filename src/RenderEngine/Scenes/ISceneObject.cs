
using OpenTK.Mathematics;
using RenderEngine.Windowing;



namespace RenderEngine.Scenes;



internal interface ISceneObject
{
    Matrix4 Transform { get; }


    void Update(FrameState frameState);
}
