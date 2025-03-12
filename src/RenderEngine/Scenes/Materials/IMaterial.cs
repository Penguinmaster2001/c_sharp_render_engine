
using RenderEngine.Scenes.Materials.Shaders;



namespace RenderEngine.Scenes.Materials;



internal interface IMaterial
{
    IShaderProgram ShaderProgram { get; }



    void Bind();
    void UnBind();


    void Delete();
}
