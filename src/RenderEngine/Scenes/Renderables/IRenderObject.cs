
using RenderEngine.Scenes.Materials;



namespace RenderEngine.Scenes.Renderables;



internal interface IRenderObject : ISceneObject
{
    IMaterial Material { get; }

    void Render();

    bool Bind();
    void UnBind();

    void Delete();
}
