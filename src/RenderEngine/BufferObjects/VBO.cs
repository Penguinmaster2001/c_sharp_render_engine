
using System.Runtime.InteropServices;

using OpenTK.Graphics.OpenGL4;



namespace RenderEngine.BufferObjects;



/// <summary>
/// OpenGL Vertex Buffer Object
/// </summary>
/// <typeparam name="T"></typeparam>
internal class VBO<T> : GLBO where T : struct
{
    public VBO(List<T> data) : base(BufferTarget.ArrayBuffer)
    {
        Bind();
        GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Marshal.SizeOf<T>(), data.ToArray(), BufferUsageHint.StaticDraw);
        UnBind();
    }



    public void SubData(List<T> data)
    {
        Bind();
        GL.BufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, data.Count * Marshal.SizeOf<T>(), data.ToArray());
        UnBind();
    }
}
