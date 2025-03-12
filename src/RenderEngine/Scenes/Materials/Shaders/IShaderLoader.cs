
namespace RenderEngine.Scenes.Materials.Shaders;



internal interface IShaderLoader
{
    IShaderProgram LoadShader(string shaderPath);
}
