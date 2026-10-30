using Framework.BuiltInObjects;

namespace Framework;

public abstract class Room
{
    
    protected List<GameObject> objects = new List<GameObject>(); 
    
    
    public virtual void Start()
    {
        foreach (GameObject obj in objects)
        {
            obj.Start();
        }
    }
    public virtual void Update(float dt)
    {
        foreach (GameObject obj in objects)
        {
            obj.Update(dt);
        }
    }
    public virtual void Draw()
    {
        foreach (GameObject obj in objects)
        {
            obj.Draw();
        }
    }
}