
using OpenTK.Mathematics;



namespace RenderEngine.Scenes.Renderables;



public interface IMesh
{
    List<Vector3> Verts { get; }
    List<Vector2> UVs { get; }
    List<uint> Indices { get; }

    int IndexCount { get; }
}
