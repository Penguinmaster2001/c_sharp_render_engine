
using RenderEngine.Scenes.Cameras;
using RenderEngine.Scenes.Renderables;



namespace RenderEngine.OpenGLRendering;



internal class Renderer : IRenderer
{
    public ICamera? MainCamera { get; set; }



    public void Render(IEnumerable<IRenderObject> renderObjects)
    {
        foreach (IRenderObject renderObject in renderObjects)
        {
            renderObject.Render();
        }
    }
}
