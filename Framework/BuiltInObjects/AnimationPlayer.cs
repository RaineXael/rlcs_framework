using System.Numerics;
using Framework;
using Framework.BuiltInObjects;
using Raylib_cs;



internal class AnimationData
{
    
    public string texPath { get; private set; }
    public float speed { get; private set; }
    public int frames { get; private set; }
    public int initialFrame { get; private set; }
    public AnimationType type {get; private set;}
    public AnimationData(string texPath, int frames, int initialFrame, float speed, AnimationType type)
    {
        this.texPath = texPath;
        this.frames = frames;
        this.speed = speed;
        this.initialFrame = initialFrame;
        this.type = type;
    }
}

public class AnimationPlayer : GameObject
{
    private bool active;
    private Dictionary<string, AnimationData> animations = new Dictionary<string, AnimationData>();
    private AnimationData? currentAnimation = null;
    AnimatedSprite animSprite;
    public AnimationPlayer(Vector2 position) : base(position)
    {
        //animSprite = new AnimatedSprite(Vector2.Zero);
    }

    public void AddAnimation(string animName, string texturePath, int frames, int initialFrame, float speed, AnimationType type)
    {
        animations.Add(animName, new AnimationData(texturePath, frames, initialFrame, speed,type));
    }
    public void PlayAnimation(string animName, bool forceRestart = false)
    {
        try
        {
            AnimationData d = animations[animName];
            if (d == currentAnimation && !forceRestart) { return; }
            currentAnimation = animations[animName];
        }
        catch (Exception)
        {
            DebugConsole.LogError($"Animation '{animName}' not found.");
        }
        if (animSprite != null)
        {
            RemoveChild(animSprite);
        }
        animSprite = new AnimatedSprite(currentAnimation.texPath, Vector2.Zero, currentAnimation.frames, currentAnimation.initialFrame, currentAnimation.speed, AnimationType.PINGPONG);
        AddChild(animSprite);
    }

    public void SetActive(bool isActive)
    {
        
        animSprite.SetActive(isActive);
        
    }

    public override void Update(float dt)
    {
        
        if (currentAnimation != null && animSprite != null)
        {
            animSprite.Update(dt);
        }
        base.Update(dt);
    }

    public override void Draw()
    {
        base.Draw();
        if (currentAnimation != null && animSprite != null)
        {
            animSprite.Draw();
        }
    }
}