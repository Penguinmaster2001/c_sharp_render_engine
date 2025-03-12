
using RenderEngine.Scenes.Cameras;
using RenderEngine.Scenes.Renderables;



namespace RenderEngine.OpenGLRendering;



internal interface IRenderer
{
    ICamera MainCamera { set; }



    void Render(IEnumerable<IRenderObject> renderObjects);
}
