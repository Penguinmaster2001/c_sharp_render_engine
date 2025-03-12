
using OpenTK.Mathematics;



namespace RenderEngine.Scene.Cameras;




/// <summary>
/// Manages a view matrix
/// </summary>
internal interface ICamera
{
    Matrix4 ViewMatrix { get; }
}
