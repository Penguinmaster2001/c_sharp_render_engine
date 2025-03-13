
using RenderEngine.Scenes.Materials.Shaders;



namespace RenderEngine.Scenes.Materials;



public interface IMaterial
{
    IShaderProgram ShaderProgram { get; }



    void Bind();
    void UnBind();


    void Delete();
}
