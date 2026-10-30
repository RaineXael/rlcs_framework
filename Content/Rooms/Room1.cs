using System.Numerics;
using Framework;
using Framework.BuiltInObjects;

public class TestRoom1 : Room
{
    public TestRoom1()
    {
        objects.Add(new TextLabel(Vector2.Zero, Localization.GetString("locstring1")));
        objects.Add(new TestGameObject(new Vector2(-8+256/2, -8+192/2)));
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