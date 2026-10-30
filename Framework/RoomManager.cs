

namespace Framework;

public static class RoomManager
{
    private static Room currentRoom;
    public static int CurrentRoomID { get;private set; }
    public static void SwitchRoom(int id)
    {
        switch (id)
        {
            case 0:
                currentRoom = new TestRoom1();
                break;
            // case 1:
            //     //currentRoom = new RoomTest();
            //     break;
            // case 2:
            //     //currentRoom = new RoomBattle();
            //     break;
            default:
                DebugConsole.LogError("Room does not exist.");
                return;
        }

        CurrentRoomID = id;
        currentRoom.Start();
        
        //unwise but ion give a swag
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }


    public static void UpdateRoom(float dt)
    {
        if (currentRoom != null)
        {
            currentRoom.Update(dt);
        }
    }
    public static void DrawRoom()
    {
        if (currentRoom != null)
        {
            currentRoom.Draw();
        }
    }
}