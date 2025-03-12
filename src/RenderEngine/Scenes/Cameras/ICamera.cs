
using OpenTK.Mathematics;



namespace RenderEngine.Scenes.Cameras;




/// <summary>
/// Manages a view matrix
/// </summary>
internal interface ICamera
{
    Matrix4 ViewMatrix { get; }
}
