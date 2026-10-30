namespace Framework;

using System.Numerics;
using Raylib_cs;

public static class InputManager
{
    private const float deadzone = 0.5f;
    private static bool leftStickPressed;
    private static bool rightStickPressed;
    private static bool upStickPressed;
    private static bool downStickPressed;
    private static bool leftStickJustPressed;
    private static bool rightStickJustPressed;
    private static bool upStickJustPressed;
    private static bool downStickJustPressed;

    private static int gamepad = 0;
    private readonly static Dictionary<string, KeyboardKey[]> defaultBindings = new()
    {
        ["move_up"] = [KeyboardKey.W, KeyboardKey.Up],
        ["move_down"] = [KeyboardKey.S, KeyboardKey.Down],
        ["move_left"] = [KeyboardKey.A, KeyboardKey.Left],
        ["move_right"] = [KeyboardKey.D, KeyboardKey.Right],
        ["interact"] = [KeyboardKey.Z, KeyboardKey.J],
        ["return"] = [KeyboardKey.X, KeyboardKey.K],
        ["menu"] = [KeyboardKey.C, KeyboardKey.L]
    };
    private readonly static Dictionary<string, GamepadButton[]> defaultGamepadBindings = new()
    {
        ["move_up"] = [(GamepadButton)1],
        ["move_down"] = [(GamepadButton)3],
        ["move_left"] = [(GamepadButton)4],
        ["move_right"] = [(GamepadButton)2],
        ["interact"] = [(GamepadButton)6],
        ["return"] = [(GamepadButton)7],
        ["menu"] = [(GamepadButton)5],
    };



    private static Dictionary<string, KeyboardKey[]> keyBinds = new();
    private static Dictionary<string, GamepadButton[]> gamepadBindings = new();

    public static void LoadKeybinds()
    {
        keyBinds = defaultBindings;
        gamepadBindings = defaultGamepadBindings;
    }

    public static bool GetActionJustPressed(string action)
    {



        if (Raylib.IsGamepadAvailable(gamepad))
        {
            //Axis
            switch (action)
            {
                case "move_up": if (upStickJustPressed) { return true; } break;
                case "move_down": if (downStickJustPressed) { return true; } break;
                case "move_left": if (leftStickJustPressed) { return true; } break;
                case "move_right": if (rightStickJustPressed) { return true; } break;
                default: break;
            }

            //Buttons
            if (gamepadBindings.ContainsKey(action))
            {
                foreach (GamepadButton button in gamepadBindings[action])
                {
                    bool value = Raylib.IsGamepadButtonPressed(gamepad, button);
                    if (value) { return true; }
                }
            }
        }

        if (keyBinds.ContainsKey(action))
        {
            foreach (KeyboardKey key in keyBinds[action])
            {
                bool value = Raylib.IsKeyPressed(key);
                if (value) { return true; }
            }
        }
        return false;
    }
    public static bool GetActionPressed(string action)
    {
        if (Raylib.IsGamepadAvailable(gamepad))
        {
            //Axis
            switch (action)
            {
                case "move_up": if (upStickPressed) { return true; } break;
                case "move_down": if (downStickPressed) { return true; } break;
                case "move_left": if (leftStickPressed) { return true; } break;
                case "move_right": if (rightStickPressed) { return true; } break;
                default: break;
            }

            //Buttons
            if (gamepadBindings.ContainsKey(action))
            {
                foreach (GamepadButton button in gamepadBindings[action])
                {
                    bool value = Raylib.IsGamepadButtonDown(gamepad, button);
                    if (value) { return true; }
                }
            }
        }
        if (keyBinds.ContainsKey(action))
        {
            foreach (KeyboardKey key in keyBinds[action])
            {
                bool value = Raylib.IsKeyDown(key);
                if (value) { return true; }
            }
        }
        return false;
    }

    public static void UpdateControllerAxis()
    {
        //done every frame

        if (Raylib.IsGamepadAvailable(gamepad))
        {
            bool prevLeftStick = leftStickPressed;
            bool prevUpStick = upStickPressed;
            bool prevDownStick = downStickPressed;
            bool prevRightStick = rightStickPressed;

            Console.WriteLine(Raylib.GetGamepadAxisMovement(0, GamepadAxis.LeftX)< -deadzone);
            
            leftStickPressed = Raylib.GetGamepadAxisMovement(0, GamepadAxis.LeftX) < -deadzone;
            rightStickPressed = Raylib.GetGamepadAxisMovement(0, GamepadAxis.LeftX) > deadzone;
            upStickPressed = Raylib.GetGamepadAxisMovement(0, GamepadAxis.LeftY) < -deadzone;
            downStickPressed = Raylib.GetGamepadAxisMovement(0, GamepadAxis.LeftY) > deadzone;
            
            leftStickJustPressed = prevLeftStick != leftStickPressed && leftStickPressed;
            upStickJustPressed = prevUpStick != upStickPressed && upStickPressed;
            downStickJustPressed = prevDownStick != downStickPressed && downStickPressed;
            rightStickJustPressed = prevRightStick != rightStickPressed && rightStickPressed;
        }
        else
        {
            leftStickPressed = false;
            rightStickPressed = false;
            downStickPressed = false;
            upStickPressed = false;
            leftStickJustPressed = false;
            rightStickJustPressed = false;
            upStickJustPressed = false;
            downStickJustPressed = false;
        }
    }

}