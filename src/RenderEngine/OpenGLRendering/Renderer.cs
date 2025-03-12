
using RenderEngine.Scenes.Cameras;
using RenderEngine.Scenes.Renderables;



namespace RenderEngine.OpenGLRendering;



internal class Renderer : IRenderer
{
    public void Render(ICamera camera, IEnumerable<IRenderObject> renderObjects)
    {
        foreach (IRenderObject renderObject in renderObjects)
        {
            if (!renderObject.Bind()) continue;

            renderObject.Material.ShaderProgram.SetCameraUniforms(camera);

            renderObject.Render();
        }
    }
}
