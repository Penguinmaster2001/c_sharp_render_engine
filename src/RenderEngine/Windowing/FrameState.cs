
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace RenderEngine.Windowing;



public record FrameState(double TimeDelta, MouseState MouseState, KeyboardState KeyboardState);
