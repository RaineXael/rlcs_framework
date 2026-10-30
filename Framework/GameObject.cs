namespace Framework;

using System.Numerics;

public abstract class GameObject
{
    /// <summary>
    /// Position in global coordinates.
    /// </summary>
    public Vector2 GlobalPosition
    {
        //Recursive getters & setters so it affects all children of a parent
        get => parent == null ? position : parent.GlobalPosition + position;
        set => position = parent == null ? value : value - parent.GlobalPosition;
    }
    public Vector2 LocalPosition
    {
        get { return position; }
        set { position = value; }
    }
    private Vector2 position;
    public int renderLayer;
    public int width { get; protected set; }
    public int height { get; protected set; }

    protected bool isOnWall;
    protected bool isOnFloor;
    protected bool isOnCeiling;

    protected GameObject? parent;
    private List<GameObject> children = new List<GameObject>();



    public GameObject()
    {

    }
    public GameObject(Vector2 position)
    {
        this.position = position;
    }

    public virtual void Start()
    {
        foreach (var child in children)
        {
            child.Start();
        }
    }

    public virtual void Update(float dt)
    {
        foreach (var child in children)
        {
            child.Update(dt);
        }
    }

    public virtual void Draw()
    {
        foreach (var child in children)
        {
            child.Draw();
        }
    }




    public void AddChild(GameObject child)
    {
        children.Add(child);
        child.parent = this;
    }

    public void Reparent(GameObject child, GameObject newParent)
    {
        RemoveChild(child);
        newParent.AddChild(child);
    }

    public void RemoveChild(GameObject child)
    {
        children.Remove(child);
        child.parent = null;
    }

    public bool IsColliding(Vector2 positionA, float widthA, float heightA)
    {
        return positionA.X < position.X + width &&
                positionA.X + widthA > position.X &&
                positionA.Y < position.Y + height &&
                positionA.Y + heightA > position.Y;
    }

}