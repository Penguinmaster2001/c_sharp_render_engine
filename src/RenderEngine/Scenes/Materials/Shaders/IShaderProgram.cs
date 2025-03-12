
using OpenTK.Mathematics;
using RenderEngine.Scenes.Cameras;



namespace RenderEngine.Scenes.Materials.Shaders;



internal interface IShaderProgram
{
    int ID { get; }
    bool Valid { get; }



    public int GetUniformLocation(string uniformName);


    
    public void SetUniform(string uniformName, Action<int> setUniformAction);



    public void SetUniformMatrix4(string uniformName, Matrix4 matrix);
    public void SetUniform1(string uniformName, float val);
    public void SetUniform1Int(string uniformName, int val);
    public void SetUniform2(string uniformName, Vector2 vector);
    public void SetUniform3(string uniformName, Vector3 vector);
    public void SetCameraUniforms(ICamera camera);



    public void Bind();
    public void UnBind();
    public void Delete();
}
