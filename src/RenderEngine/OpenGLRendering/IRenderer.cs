
using RenderEngine.Scenes.Cameras;
using RenderEngine.Scenes.Renderables;



namespace RenderEngine.OpenGLRendering;



internal interface IRenderer
{
    void Render(ICamera camera, IEnumerable<IRenderObject> renderObjects);
}
