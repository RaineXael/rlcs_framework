using System.Numerics;
using Framework;
using Raylib_cs;


namespace HelloWorld;

internal static class Program
{
    // STAThread is required if you deploy using NativeAOT on Windows
    // See https://github.com/raylib-cs/raylib-cs/issues/301
    [STAThread]
    public static void Main()
    {
        bool debug = true;
        bool intScaling = false;
        
        Localization.SwitchLanguage("en");
        InputManager.LoadKeybinds();
        
        int gameWidth = 256;
        int gameHeight = 192;

        int windowWidth = 256*3;
        int windowHeight = 192*3;

        Raylib.InitWindow(windowWidth, windowHeight, "RLCS_FRAMEWORK");
        Raylib.SetWindowIcon(Raylib.LoadImage("./resources/spr_icon.png"));
        
        Raylib.InitAudioDevice();

        //FontManager.SetFont(false,Raylib.LoadFontEx("resources/fonts/Empire.ttf", 28, null, 0),14,0);
        FontManager.SetFont(false, Raylib.LoadFontEx("resources/fonts/04B_03.ttf", 32, null, 0),8,0);
        FontManager.SetFont(true,Raylib.LoadFontEx("resources/fonts/04B_03.ttf", 32, null, 0),8,0);
        AssetManager.InitializeFallbacks();
       
        
        RoomManager.SwitchRoom(0);
        Raylib.SetTargetFPS(60);

        RenderTexture2D target = Raylib.LoadRenderTexture(gameWidth, gameHeight);
        Rectangle sourceRect = new Rectangle();
        Rectangle destRect = new Rectangle();
        ResizeRenderSize(intScaling, ref windowWidth, ref windowHeight, gameWidth, gameHeight, ref sourceRect, ref destRect, ref target);
        Raylib.SetWindowState(ConfigFlags.ResizableWindow);
        
        
        

        while (!Raylib.WindowShouldClose())
        {
            if (Raylib.IsWindowResized()) ResizeRenderSize(intScaling, ref windowWidth, ref windowHeight, gameWidth, gameHeight, ref sourceRect, ref destRect, ref target);

            if (Raylib.IsKeyPressed(KeyboardKey.F4))
            {
               Raylib.ToggleFullscreen();
            }

            InputManager.UpdateControllerAxis();
            RoomManager.UpdateRoom(Raylib.GetFrameTime());
            MusicManager.UpdateStream();
            
            
            if (Raylib.IsKeyPressed(KeyboardKey.Kp1))
            {
                RoomManager.SwitchRoom(0);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Kp2))
            {
                RoomManager.SwitchRoom(1);
            }
            


            //Draw to Texture
            Raylib.BeginTextureMode(target);
                Raylib.ClearBackground(Color.Gray);
                RoomManager.DrawRoom();
             
            Raylib.EndTextureMode();


            Raylib.ClearBackground(Color.Black);
            Raylib.BeginDrawing();
            
            Raylib.DrawTexturePro(target.Texture, sourceRect, destRect, new Vector2(0, 0), 0f, Color.White);

            if (debug)
            {
                DebugConsole.Update();
                DebugConsole.Draw();
            }

            FontManager.DrawString(Raylib.GetFPS().ToString(),0,0,Color.White);
            Raylib.EndDrawing();
        }
        AssetManager.UnloadAllTextures();
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    public static void KeepAspectCenteredInteger(int screenWidth, int screenHeight, int gameWidth, int gameHeight, ref Rectangle sourceRect, ref Rectangle destRect)
    {
        sourceRect.X = 0.0f;
        sourceRect.Y = (float)gameHeight;
        sourceRect.Width = (float)gameWidth;
        sourceRect.Height = (float)-gameHeight;

        int ratio_x = (screenWidth / gameWidth);
        int ratio_y = (screenHeight / gameHeight);
        float resizeRatio = (float)((ratio_x < ratio_y) ? ratio_x : ratio_y);

        destRect.X = (float)(int)((screenWidth - (gameWidth * resizeRatio)) * 0.5f);
        destRect.Y = (float)(int)((screenHeight - (gameHeight * resizeRatio)) * 0.5f);
        destRect.Width = (float)(int)(gameWidth * resizeRatio);
        destRect.Height = (float)(int)(gameHeight * resizeRatio);
    }

    public static void KeepAspectCentered(int screenWidth, int screenHeight, int gameWidth, int gameHeight, ref Rectangle sourceRect, ref Rectangle destRect)
    {
    sourceRect.X = 0.0f;
    sourceRect.Y = (float)gameHeight;
    sourceRect.Width = (float)gameWidth;
    sourceRect.Height = (float)-gameHeight;

    float ratio_x = ((float)screenWidth/(float)gameWidth);
    float ratio_y = ((float)screenHeight/(float)gameHeight);
    float resizeRatio = (ratio_x < ratio_y ? ratio_x : ratio_y);

    destRect.X = (float)(int)((screenWidth - (gameWidth*resizeRatio))*0.5f);
    destRect.Y = (float)(int)((screenHeight - (gameHeight*resizeRatio))*0.5f);
    destRect.Width = (float)(int)(gameWidth*resizeRatio);
    destRect.Height = (float)(int)(gameHeight*resizeRatio);
    }

    public static void ResizeRenderSize(bool integerScaling, ref int screenWidth, ref int screenHeight, int gameWidth, int gameHeight, ref Rectangle sourceRect, ref Rectangle destRect, ref RenderTexture2D target)
{
    screenWidth = Raylib.GetScreenWidth();
    screenHeight = Raylib.GetScreenHeight();

        if (integerScaling)
        {
            KeepAspectCenteredInteger(screenWidth, screenHeight, gameWidth, gameHeight, ref sourceRect, ref destRect);
        }
        else
        {
            KeepAspectCentered(screenWidth, screenHeight, gameWidth, gameHeight, ref sourceRect, ref destRect);
        }
    

    Raylib.UnloadRenderTexture(target);
    target = Raylib.LoadRenderTexture((int)sourceRect.Width, -(int)sourceRect.Height);
}


}


