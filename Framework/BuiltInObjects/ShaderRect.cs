using System.Numerics;
using Framework;
using Raylib_cs;

public class ShaderRect : GameObject
{
    Shader shader;
    int timeLoc;
    int resolutionLoc;
    public ShaderRect(string shaderPath, Vector2 position, Vector2 size) : base(position)
    {
        shader = AssetManager.LoadFragShader(shaderPath);
        width = (int)size.X;
        height = (int)size.Y;

        //Set shader param locations
        timeLoc = Raylib.GetShaderLocation(shader, "iTime");
        resolutionLoc = Raylib.GetShaderLocation(shader, "iResolution");
    }

    public override void Update(float dt)
    {
        base.Update(dt);
        float time = (float)Raylib.GetTime();
        //Set shader params here
        Raylib.SetShaderValue(shader, timeLoc, time, ShaderUniformDataType.Float);
        Raylib.SetShaderValue(shader, resolutionLoc, new Vector2(width, height), ShaderUniformDataType.Vec2);
    }
    
    public override void Draw()
    {

        base.Draw();
        Raylib.BeginShaderMode(shader);
            Raylib.DrawRectangle((int)GlobalPosition.X, (int)GlobalPosition.Y, width, height,Color.Magenta);
        Raylib.EndShaderMode();
    }
}