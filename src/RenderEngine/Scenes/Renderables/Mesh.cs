
using OpenTK.Mathematics;



namespace RenderEngine.Scenes.Renderables;



internal class Mesh(List<Vector3> verts, List<Vector2> uvs, List<uint> indices) : IMesh
{
    public List<Vector3> Verts { get; } = verts;
    public List<Vector2> UVs { get; } = uvs;
    public List<uint> Indices { get; } = indices;
    public int IndexCount => Indices.Count;
}
