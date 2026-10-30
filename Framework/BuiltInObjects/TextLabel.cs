using System.Numerics;
using Raylib_cs;

namespace Framework.BuiltInObjects;

public class TextLabel : GameObject
{
    private int width = 220;
    private string text;
    private int lineHeight = 12;
    private bool altFont = false; 
    private Color color;
    public string Text
    {
        get { return text;}
        set
        {
            text = SetStringProcessed(value);
            VisibleRatio = 1;
        }
    }

    private string SetStringProcessed(string value)
    {
        string builder = "";
        string currentLine = "";
        string currentWord = "";
        foreach (char c in value)
        {
            
            currentWord += c;
            
            if (FontManager.MeasureText(currentLine+currentWord) > width)
            {
                //Whenever overflow
                builder +=currentLine+"\n";
                currentLine = "";
                
               
            }

            if (c.Equals(' '))
            {
                currentLine += currentWord;
                currentWord = "";
            }
        }

        currentLine += currentWord;
        builder +=currentLine+"\n";
        FontManager.MeasureText(value);
        return builder;
    }
    private bool useSubFont;
    
    public int visibleCharacters = 0;
    public float VisibleRatio{ get{
        if (Text.Length == 0)
        {
            return 0;
        } 
        return visibleCharacters / (float)Text.Length;
        
    }
    set
    {
        visibleCharacters = (int)value * Text.Length;
    }
    }
    
    public TextLabel(Vector2 position, string Text,bool subFont=false,int width = 220):base(position)
    {
        this.width = width;
        useSubFont = subFont;
        this.Text = Text;
        VisibleRatio = 1f;
        color = Color.White;
    }
    public TextLabel(Vector2 position, string Text, Color color, bool subFont=false,int width = 220):base(position)
    {
        this.width = width;
        useSubFont = subFont;
        this.Text = Text;
        VisibleRatio = 1f;
        this.color = color;
    }
    
    public override void Start()
    {
        
    }

    public override void Draw()
    {
        visibleCharacters = Math.Clamp(visibleCharacters, 0, text.Length);
        string visibleText = text.Substring(0, visibleCharacters);
        string[] lines = visibleText.Split('\n');
        int currentY = (int)GlobalPosition.Y;

        foreach (string line in lines)
        {
            FontManager.DrawString(line, (int)GlobalPosition.X, currentY, color,useSubFont);
            currentY += lineHeight;
        }
    }
}