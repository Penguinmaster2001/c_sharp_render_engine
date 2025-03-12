
using OpenTK.Graphics.OpenGL4;



namespace RenderEngine.BufferObjects;



/// <summary>
/// OpenGL buffer obj abstract class
/// </summary>
internal abstract class GLBO
{
    public int ID { get; protected set; }
    public BufferTarget BufferTarget { get; }



    public GLBO(BufferTarget bufferTarget)
    {
        ID = GL.GenBuffer();
        BufferTarget = bufferTarget;
    }



    public virtual void Bind() => GL.BindBuffer(BufferTarget, ID);
    public virtual void UnBind() => GL.BindBuffer(BufferTarget, 0);
    public void Delete() => GL.DeleteBuffer(ID);
}
