using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

namespace Framework.BuiltInObjects;

public enum AnimationType
{
    FORWARD, REVERSE, PINGPONG
}

public class AnimatedSprite : Sprite
{

    private bool disabled;
    private Rectangle sliceRect;
    public float speed = 8f;
    private int frames;
    private int currentFrame;
    private float timer = 1;
    private int frameWidth;

    private int frameIncrement = 1;
    private bool pingPong = false;

    public AnimatedSprite(Vector2 position) : base(null, position)
    {

    }

    public void SetActive(bool isActive)
    {
        //reset to frame 1 on inactive (variable for later, set as default for now)
        //if not active, reset sprite to 0.
        if (disabled == isActive)
        {
            if (!isActive)
            {
                currentFrame = 0; //default for now, should be editable later
                                  //sliceRect = new Rectangle(0, 0, frameWidth, tex.Height);
            }
            else
            {
                currentFrame = 0;
            }
        }
        disabled = !isActive;
    }

    public AnimatedSprite(string texPath, Vector2 position, int frames, int initialFrame = 0, float speed = 8f, AnimationType type = AnimationType.FORWARD) : base(texPath, position)
    {
        currentFrame = initialFrame;
        this.speed = speed;
        this.frames = frames;
        frameWidth = tex.Width / frames;
        sliceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, tex.Height);
        SwitchAnimationType(type);
    }

    public void SwitchAnimationType(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.FORWARD:
                frameIncrement = 1;
                pingPong = false;
                break;
            case AnimationType.REVERSE:
                frameIncrement = -1;
                pingPong = false;
                break;
            case AnimationType.PINGPONG:
                frameIncrement = 1;
                pingPong = true;
                break;

        }
    }
    private float a = 0;
    public override void Update(float dt)
    {
        if (!disabled)
        {
            if (timer <= 0)
            {
                //go to next frame
                currentFrame += frameIncrement;
                if (currentFrame >= frames)
                {
                    //forward overflow
                    if (pingPong)
                    {

                        frameIncrement *= -1;
                        currentFrame = frames - 2;
                    }
                    else
                    {
                        currentFrame = 0;
                    }


                }

                if (currentFrame < 0)
                {
                    //backward overflow
                    if (pingPong)
                    {
                        frameIncrement *= -1;
                        currentFrame = 1;
                    }
                    else
                    {
                        currentFrame = frames - 1;
                    }
                }

                sliceRect.X = currentFrame * frameWidth;
                timer = 1;

                //DebugConsole.Log(a.ToString());
                a = 0;
            }
            else
            {
                a += 1;
                timer -= dt * speed;
            }
        }


        base.Update(dt);
    }

    public override void Draw()
    {
        Raylib.DrawTextureRec(tex, sliceRect, GlobalPosition, Color.White);
        //Raylib.DrawText(currentFrame.ToString(),(int)GlobalPosition.X, (int)GlobalPosition.Y, 12,Color.White);
    }
}