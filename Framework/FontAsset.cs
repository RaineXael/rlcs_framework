using Raylib_cs;

namespace Framework;

public class FontAsset
{
    public float spacing{ get; private set; }
    public float fontSize{ get; private set; } 
    public Font font { get; private set; }

    public FontAsset(Font loadFont, int defaultSize, int defaultSpacing)
    {
        Raylib.SetTextureFilter(loadFont.Texture, TextureFilter.Point);
        font = loadFont;
        fontSize = defaultSize;
        spacing = defaultSpacing;
    }
}