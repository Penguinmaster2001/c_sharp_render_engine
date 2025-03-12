
using OpenTK.Graphics.OpenGL4;



namespace RenderEngine.BufferObjects;



/// <summary>
/// OpenGL Index Buffer Object
/// </summary>
internal class IBO : GLBO
{
    public IBO(List<uint> data) : base(BufferTarget.ElementArrayBuffer)
    {
        Bind();
        GL.BufferData(BufferTarget.ElementArrayBuffer, data.Count * sizeof(uint), data.ToArray(), BufferUsageHint.StaticDraw);
        UnBind();
    }
}
