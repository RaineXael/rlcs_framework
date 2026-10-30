using System.Numerics;
using Raylib_cs;
namespace Framework;


public static class AssetManager
{
    private const string baseDir = "resources/";
    private static Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
    public static Texture2D fallbackTexture;
    
    /// <summary>
    /// Loads Texture into memory and returns it.
    /// </summary>
    /// <param name="assetName"></param>
    public static Texture2D LoadTexture(string assetName)
    {
        if (!_textures.ContainsKey(assetName))
        {
            try
            {
                Texture2D tex = Raylib.LoadTexture(baseDir + assetName);
                if (tex.Dimensions == Vector2.Zero)
                {
                    throw new FileNotFoundException($"Texture '{assetName}' not found in the AssetManager.");
                    
                }
                Console.WriteLine("Texture found and added.");
                _textures.Add(assetName, tex);
                return tex;
            }
            catch (FileNotFoundException)
            {
                DebugConsole.LogError($"AssetManager: Texture not found in path '{baseDir + assetName}'");
                return fallbackTexture;
            }
        }
        Console.WriteLine("Texture already exists. Returning ");
        return GetTexture(assetName);
    }

    public static Texture2D GetTexture(string assetName)
    {
        if (_textures.ContainsKey(assetName))
        {
            return _textures[assetName];
        }
        else
        {
            // You might want to throw an exception or return a default texture
            DebugConsole.LogError($"Texture '{assetName}' not found in the AssetManager.");
            return fallbackTexture;
        }
    }

    public static void UnloadTexture(string assetName)
    {
        if (!_textures.ContainsKey(assetName))
        {
            DebugConsole.LogError($"Texture '{assetName}' not found in the AssetManager.");
            return;
        }
        Texture2D t = _textures[assetName];
        _textures.Remove(assetName);
        Raylib.UnloadTexture(t);
    }

    public static void UnloadAllTextures()
    {
        foreach (KeyValuePair<string, Texture2D> t in _textures)
        {
            UnloadTexture(t.Key);
        }
    }

    public static void InitializeFallbacks()
    {
        fallbackTexture = Raylib.LoadTexture("./resources/spr_default.png");
    }
}
