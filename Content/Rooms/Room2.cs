using System.Numerics;
using Framework;
using Framework.BuiltInObjects;

public class TestRoom2 : Room
{
    public TestRoom2()
    {
        objects.Add(new TextLabel(Vector2.Zero, Localization.GetString("locstring2")));
        objects.Add(new Sprite("spr_icon.png",new Vector2(-8+256/2, -8+192/2)));
    }

    public override void Draw()
    {
        base.Draw();
    }

    public override void Update(float dt)
    {
        base.Update(dt);
    }
}