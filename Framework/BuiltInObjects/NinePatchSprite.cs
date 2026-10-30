using System.Numerics;
using Raylib_cs;

namespace Framework.BuiltInObjects;

public class NinePatchSprite:GameObject
{
    Texture2D tex;
    private NPatchInfo npatchInfo;
    public NinePatchSprite(string texturePath, Vector2 position, Vector2 size, int leftMargin, int rightMargin, int bottomMargin, int topMargin) : base(position)
    {
        width = (int)size.X;
        height = (int)size.Y;

        tex = AssetManager.LoadTexture(texturePath);
        npatchInfo = new NPatchInfo
        {
            Source = new Rectangle(0, 0, tex.Width, tex.Height),
            Left = leftMargin,
            Top = topMargin,
            Right = rightMargin,
            Bottom = bottomMargin,

            Layout = NPatchLayout.NinePatch
        };
     

    }

    public void ResetSize(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    
    public override void Draw()
    {
        Vector2 drawPos = new Vector2((int)GlobalPosition.X, (int)GlobalPosition.Y);
        Raylib.DrawTextureNPatch(tex,npatchInfo,new Rectangle(drawPos,width,height),Vector2.Zero, 0,Color.White);
        base.Draw();
    }
}