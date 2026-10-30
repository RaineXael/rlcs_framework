using System.Numerics;
using Raylib_cs;

namespace Framework.BuiltInObjects;

public class Sprite:GameObject
{
    protected Texture2D tex;
    public Sprite(string texPath, Vector2 position) : base(position)
    {
        tex = AssetManager.LoadTexture(texPath);
        width = tex.Width;
        height = tex.Height;
    }

    
    
    public override void Draw()
    {
        Raylib.DrawTextureV(tex,GlobalPosition,Color.White);
    }
}