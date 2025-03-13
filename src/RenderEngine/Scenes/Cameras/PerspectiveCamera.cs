
using OpenTK.Mathematics;



namespace RenderEngine.Scenes.Cameras;



/// <summary>
/// Basic perspective camera class
/// </summary>
internal class PerspectiveCamera(float fov, int viewWidth, int viewHeight, float clipNear, float clipFar) : SceneObject, ISceneCamera
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


    public float ClipNear
    {
        get => _clipNear;

        set
        {
            _clipNear = value;
            _modified = true;
        }
    }
    protected float _clipNear = clipNear;


    public float ClipFar
    {
        get => _clipFar;

        set
        {
            _clipFar = value;
            _modified = true;
        }
    }
    protected float _clipFar = clipFar;

    public int ViewWidth
    {
        get => _viewWidth;

        set
        {
            _viewWidth = value;
            _modified = true;
        }
    }
    private int _viewWidth = viewWidth;


    public int ViewHeight
    {
        get => _viewHeight;

        set
        {
            _viewHeight = value;
            _modified = true;
        }
    }
    private int _viewHeight = viewHeight;



    protected void UpdateViewMatrix()
    {
        _viewMatrix = Matrix4.CreatePerspectiveFieldOfView(_fov, ViewWidth / ViewHeight, ClipNear, ClipFar)
            * Matrix4.LookAt(Position, Position + Vector3.UnitZ, Vector3.UnitY);

        _modified = false;
    }
}
