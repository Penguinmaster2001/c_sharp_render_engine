
using RenderEngine.Scenes.Materials;



namespace RenderEngine.Scenes.Renderables;



public interface IRenderObject : ISceneObject
{
    IMaterial Material { get; }

    void Render();

    bool Bind();
    void UnBind();

    void Delete();
}
