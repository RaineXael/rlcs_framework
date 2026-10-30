using System.Numerics;
using Framework;
using Framework.BuiltInObjects;

public class TestGameObject : GameObject
{
    private float speed = 50f;
    private Vector2 velocity;
    public TestGameObject(Vector2 position):base(position)
    {
        AddChild(new Sprite("spr_icon.png",Vector2.Zero));
        velocity = new Vector2(speed,speed);
    }

    public override void Update(float dt)
    {
        base.Update(dt);
        GlobalPosition += velocity * dt;
        if(GlobalPosition.X > 240)
        {
            velocity.X = -speed;
        }
        if(GlobalPosition.X < 0)
        {
            velocity.X = speed;
        }
        if(GlobalPosition.Y > 176)
        {
            velocity.Y = -speed;
        }
        if(GlobalPosition.Y < 0)
        {
            velocity.Y = speed;

            DebugConsole.Log($"Debug Console Demo! I hit the top wall at ({GlobalPosition.X},{GlobalPosition.Y})");
        }
    }
}