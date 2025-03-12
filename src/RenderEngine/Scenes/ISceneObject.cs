
using OpenTK.Mathematics;



namespace RenderEngine.Scenes;



internal interface ISceneObject
{
    Matrix4 Transform { get; }


    void Update(double timeDelta);
}
