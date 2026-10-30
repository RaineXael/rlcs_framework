namespace Framework;
using System.Numerics;
using Raylib_cs;

public static class Util
{
    public static float Lerp(float a, float b, float t)
    {
        return a + t * (b - a);
    }
    
    public static float MoveTowards(float current, float target, float speed)
    {
      
        float delta = target - current;

        
        if (MathF.Abs(delta) <= speed)
        {
            return target;
        }
        
        return current + MathF.Sign(delta) * speed;
    }

    public static void DrawTextureQuad2D(Texture2D texture, Vector2 topLeft, Vector2 topRight, Vector2 bottomRight, Vector2 bottomLeft)
    {
        Rlgl.SetTexture(texture.Id);

        Rlgl.Begin(DrawMode.Quads);
        Rlgl.Color4ub(255, 255, 255, 255);

        // Top-Left
        Rlgl.TexCoord2f(0.0f, 0.0f);
        Rlgl.Vertex2f(topLeft.X, topLeft.Y);

        // Bottom-Left
        Rlgl.TexCoord2f(0.0f, 1.0f);
        Rlgl.Vertex2f(bottomLeft.X, bottomLeft.Y);

        // Bottom-Right
        Rlgl.TexCoord2f(1.0f, 1.0f);
        Rlgl.Vertex2f(bottomRight.X, bottomRight.Y);

        // Top-Right
        Rlgl.TexCoord2f(1.0f, 0.0f);
        Rlgl.Vertex2f(topRight.X, topRight.Y);

        Rlgl.End();

        Rlgl.SetTexture(0);
    }
}