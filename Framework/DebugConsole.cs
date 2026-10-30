using Raylib_cs;
using System.Numerics;
using Framework.BuiltInObjects;

namespace Framework;

public static class DebugConsole
{
    private static bool panelDisplayed;
    private static List<TextLabel> visibleMessages = new List<TextLabel>();
   
    private const int MAX_MESSAGES = 30;
    public static void Log(string? message)
    {
        if(message == null)
        {
            Console.WriteLine("<NULL!!>");
            return;
        }
        Console.WriteLine(message);
        AddNewMessage(message, Color.White);
    }
    public static void LogError(string message)
    {
        Console.WriteLine($"!!!- {message} -!!!");
        AddNewMessage(message, Color.Red);
    }

    private static void AddNewMessage(string message, Color color)
    {
        TextLabel label = new TextLabel(new Vector2(0,0),message,color, false,99999);
        
        visibleMessages.Add(label);
        if(visibleMessages.Count > MAX_MESSAGES)
        {
            visibleMessages.RemoveAt(0);
        }
        SetLabelPositions();
    }

    public static void Draw()
    {
        if (panelDisplayed)
        {
            Raylib.DrawRectangle(0,0,Raylib.GetScreenWidth(),Raylib.GetScreenHeight(), new Color(20,20,20,230));
            foreach(TextLabel l in visibleMessages)
            {
            
                l.Draw();
            }
        }
    }

    public static void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Grave))
        {
            panelDisplayed = !panelDisplayed;
            if (panelDisplayed)
            {
                SetLabelPositions();
            }
        }
    }

    private static void SetLabelPositions()
    {
        int i = 0;
        int sep = 10;
        foreach(TextLabel l in visibleMessages)
        {
            l.GlobalPosition = new Vector2(4,sep*i);
            i++;
        }
    }

}