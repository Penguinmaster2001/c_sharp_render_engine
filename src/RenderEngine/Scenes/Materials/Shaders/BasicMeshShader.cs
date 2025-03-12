
using RenderEngine.Scenes.Cameras;



namespace RenderEngine.Scenes.Materials.Shaders;



internal class BasicMeshShader(int id, bool valid) : ShaderProgram(id, valid)
{
    public override void SetCameraUniforms(ICamera camera)
    {
        SetUniformMatrix4("view", camera.ViewMatrix);
    }
}