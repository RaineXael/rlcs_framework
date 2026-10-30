# Raylib C# Framework
A framework for Raylib C#.

## What is this?
I've been making a game with Raylib's C# bindings. There are some systems that could be reused for future game projects with the framework. This is the result: A bunch of pre-made classes for handling the following:
* Inputs, Keyboard & Controller
* Localization strings
* Asset Management and Loading (Textures only for now)
* Room Management
* GameObject system
* Sprites, Nine Patch Sprites, Animated Sprites and Text-Labels as built-in Game Objects. 
* Pixel Perfect Rendering (Made for tiny resolution games like 256x192, scaled up depending on window size).
* Music Management

## Install Instructions
1. Install a Dotnet SDK. It works with anything at least above .NET 8.0.
2. Clone the files, either by downloading it through Github or through the git command line.
3. Either run it via an IDE like VSCode, or run it through the command line with `dotnet run` inside the project root. It should restore and run it for you.
4. If you want to export an executable without having to include all the DLLs, run `dotnet publish -r <target>`, replacing the target with your choice:
    * `win-x64`: Windows
    * `linux-x64`: Linux
    
    Note: You can replace `x64` with `arm` if you're targeting that CPU.

## Progress
This is an early upload, and as of now is absolutely not complete or documented. Work will continue on this when I'm less busy.

## Dependencies:
* [Raylib-cs](https://www.nuget.org/packages/Raylib-cs/5.0.0)
* [Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/)
-----

And no, this doesn't have to do with the champion series of a certain car soccer game.