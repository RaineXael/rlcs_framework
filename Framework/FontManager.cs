using System.Numerics;

namespace Framework;
using Raylib_cs;
public static class FontManager
{
    public static FontAsset mainFont;
    public static FontAsset subFont;

    public static void SetFont(bool isSubFont, Font loadFont, int defaultSize, int textSpacing = 0)
    {
        FontAsset fontAsset = new FontAsset(loadFont, defaultSize, textSpacing);
        if (isSubFont)
        {
            subFont = fontAsset;
        }
        else
        {
            mainFont = fontAsset;
        }
        
    }

    public static void DrawString(string text, int x, int y, Color color, bool isSubFont = false)
    {
        FontAsset drawingFont = mainFont;
        if (isSubFont)
        {
            drawingFont = subFont;
        }
        Raylib.DrawTextEx(drawingFont.font, text,new Vector2(x,y),drawingFont.fontSize, drawingFont.spacing, color);
        //Raylib.DrawTextPro(MainFont, text, new Vector2(x,y),Vector2.Zero,0,fontSize,8.0f, color);
    }

    public static int MeasureText(string text, bool isSubFont = false)
    {
        FontAsset drawingFont = mainFont;
        if (isSubFont)
        {
            drawingFont = subFont;
        }
        
        
        if (drawingFont.fontSize == 0) throw new Exception("Font size must be specified");
        
        Vector2 measure = Raylib.MeasureTextEx(drawingFont.font, text, drawingFont.fontSize, drawingFont.spacing);
        return (int)measure.X;
    }
    
}