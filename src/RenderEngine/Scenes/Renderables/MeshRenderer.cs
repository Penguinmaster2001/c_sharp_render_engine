
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using RenderEngine.BufferObjects;
using RenderEngine.Scenes.Materials;



namespace RenderEngine.Scenes.Renderables;



public class MeshRenderer : SceneObject, IRenderObject
{
    public IMesh Mesh { get; }
    public IMaterial Material { get; }

    private VAO? _vao;
    private VBO<Vector3>? _vertexVbo;
    private VBO<Vector2>? _uvVbo;
    private IBO? _ibo;
    private int _indexCount;

    private bool _bound;



    public MeshRenderer(IMaterial material, IMesh mesh)
    {
        Material = material;
        Mesh = mesh;

        Refresh();
    }



    public void Refresh()
    {
        _bound = false;

        _vao = new();
        _vao.Bind();

        _vertexVbo = new(Mesh.Verts);
        _vertexVbo.Bind();
        _vao.LinkToVAO(0, 3, _vertexVbo);
        _vertexVbo.UnBind();

        _uvVbo = new(Mesh.UVs);
        _uvVbo.Bind();
        _vao.LinkToVAO(1, 2, _uvVbo);
        _uvVbo.UnBind();

        _vao.UnBind();

        _ibo = new(Mesh.Indices);

        _indexCount = Mesh.IndexCount;
    }



    public bool Bind()
    {
        _bound = false;

        if (_vao is null || _vertexVbo is null || _uvVbo is null || _ibo is null || _indexCount <= 0) return false;


        Material.Bind();

        Material.ShaderProgram.SetUniformMatrix4("model", Transform);

        _vao.Bind();
        _ibo.Bind();

        _bound = true;

        return true;
    }



    public void Render()
    {
        if (_bound)
        {
            GL.DrawElements(PrimitiveType.Triangles, _indexCount, DrawElementsType.UnsignedInt, 0);
        }

        UnBind();
    }



    public void UnBind()
    {
        if (_bound)
        {
            Material.UnBind();
            _vao?.UnBind();
            _ibo?.UnBind();
        }

        _bound = false;
    }



    public void Delete()
    {
        _ibo?.Delete();
        _vertexVbo?.Delete();
        _uvVbo?.Delete();
        _vao?.Delete();
    }
}
