
using OpenTK.Mathematics;



namespace RenderEngine.Scene.Cameras;



/// <summary>
/// Basic perspective camera class
/// </summary>
internal class PerspectiveCamera(float fov, float aspectRatio, float clipNear, float clipFar) : ICamera
{
    public Matrix4 ViewMatrix
    {
        get
        {
            if (_modified)
            {
                UpdateViewMatrix();
            }

            return _viewMatrix;
        }
    }
    private Matrix4 _viewMatrix;


    public float Fov
    {
        get => _fov;

        set
        {
            _fov = value;
            _modified = true;
        }
    }
    protected float _fov = fov;


    public float AspectRatio
    {
        get => _aspectRatio;

        set
        {
            _aspectRatio = value;
            _modified = true;
        }
    }
    protected float _aspectRatio = aspectRatio;


    public float ClipNear
    {
        get => _clipNear;

        private set
        {
            _clipNear = value;
            _modified = true;
        }
    }
    protected float _clipNear = clipNear;


    public float ClipFar
    {
        get => _clipFar;

        private set
        {
            _clipFar = value;
            _modified = true;
        }
    }
    protected float _clipFar = clipFar;


    /// <summary>
    /// Set to true when modified so call to <see cref="UpdateViewMatrix"/>
    /// only happens once per get <see cref="ViewMatrix"/>
    /// </summary>
    protected bool _modified = true;



    protected void UpdateViewMatrix()
    {
        _viewMatrix = Matrix4.CreatePerspectiveFieldOfView(_fov, _aspectRatio, ClipNear, ClipFar);

        _modified = false;
    }
}
