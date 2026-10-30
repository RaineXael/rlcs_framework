using Raylib_cs;

namespace Framework;

public static class MusicManager
{
    private static Music music;
    private static bool playing;
    
    //Bug when you go through room 0 then 1
    //StopMusic -> StartMusic -> Crash maybe. Could it be due to unloading the music in an unsafe way?
    public static void StartMusic(string path)
    {
        StopMusic();
        //music = Raylib.LoadMusicStream("resources/audio/mus/mus_test.mp3");
        music = Raylib.LoadMusicStream(path);
        Raylib.PlayMusicStream(music);
        playing = true;
    }

    public static void StopMusic()
    {
        if (playing)
        {
            playing = false;
            Raylib.StopMusicStream(music);  //the line that's causing the crash upon switching to room 1, 0, then 1 again
            Raylib.UnloadMusicStream(music);
        }  
    }

    public static void UpdateStream()
    {
        if (playing)
        {
            Raylib.UpdateMusicStream(music); // Update music buffer with new stream data
        }
    }
}