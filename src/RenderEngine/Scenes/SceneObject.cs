
using OpenTK.Mathematics;

using RenderEngine.Windowing;



namespace RenderEngine.Scenes;



public abstract class SceneObject : ISceneObject
{
    public IScene? Scene { get; protected set; }
    public Matrix4 Transform { get; protected set; }

    public Vector3 Position
    {
        get => _position;

        set
        {
            _position = value;
            _modified = true;
        }

    }
    private Vector3 _position = Vector3.Zero;


    public Vector3 Scale
    {
        get => _scale;

        set
        {
            _scale = value;
            _modified = true;
        }

    }
    private Vector3 _scale = Vector3.One;


    public Quaternion Rotation
    {
        get => _rotation;

        set
        {
            _rotation = value;
            _modified = true;
        }
    }
    protected Quaternion _rotation = Quaternion.Identity;


    protected bool _modified = true;



    public void UpdateTransform()
    {
        if (!_modified) return;


        // TRS matrix
        Transform = Matrix4.CreateScale(Scale)
            * Matrix4.CreateFromQuaternion(Rotation)
            * Matrix4.CreateTranslation(Position);

        _modified = false;
    }



    public virtual void Update(FrameState frameState)
    {
        UpdateTransform();
    }



    public virtual void AddToScene(IScene scene)
    {
        Scene = scene;
    }
}
