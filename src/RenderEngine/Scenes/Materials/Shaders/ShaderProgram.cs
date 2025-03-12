
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using RenderEngine.Scenes.Cameras;



namespace RenderEngine.Scenes.Materials.Shaders;



internal abstract class ShaderProgram(int id, bool valid) : IShaderProgram
{
    public int ID { get; protected set; } = id;
    public bool Valid { get; protected set; } = valid;



    public int GetUniformLocation(string uniformName)
    {
        int location = GL.GetUniformLocation(ID, uniformName);

        return location;
    }



    public void SetUniform(string uniformName, Action<int> setUniformAction)
    {
        if (!Valid) return;

        int location = GetUniformLocation(uniformName);

        if (location < 0) return;

        setUniformAction(location);
    }



    public void SetUniformMatrix4(string uniformName, Matrix4 matrix) => SetUniform(uniformName, location => GL.ProgramUniformMatrix4(ID, location, true, ref matrix));
    public void SetUniform1(string uniformName, float val) => SetUniform(uniformName, location => GL.ProgramUniform1(ID, location, val));
    public void SetUniform1Int(string uniformName, int val) => SetUniform(uniformName, location => GL.ProgramUniform1(ID, location, val));
    public void SetUniform2(string uniformName, Vector2 vector) => SetUniform(uniformName, location => GL.ProgramUniform2(ID, location, vector));
    public void SetUniform3(string uniformName, Vector3 vector) => SetUniform(uniformName, location => GL.ProgramUniform3(ID, location, vector));
    public void SetUniform4(string uniformName, Vector4 vector) => SetUniform(uniformName, location => GL.ProgramUniform4(ID, location, vector));

    public abstract void SetCameraUniforms(ICamera camera);



    public void Bind()
    {
        if (!Valid) return;

        GL.UseProgram(ID);
    }



    public void UnBind()
    {
        if (!Valid) return;

        GL.UseProgram(0);
    }



    public void Delete()
    {
        if (!Valid) return;

        GL.DeleteProgram(ID);
        ID = -1;
        Valid = false;
    }
}
