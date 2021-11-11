using ExitGames.Client.Photon;
using Photon.Realtime;

//カスタムプロパティーを管理するクラス
public static class PlayerPropertiesManager
{
    const string deadScore = "d";
    const string KeyStartTime = "StartTime";
    static readonly Hashtable propertiesToSet = new Hashtable();

    public static int DeadGetScore(this Player player)
    {
        return (player.CustomProperties[deadScore] is int score) ? score : 0;
    }

    public static void DeadAddScore(this Player player, int value)
    {
        propertiesToSet[deadScore] = player.DeadGetScore() + value;
        player.SetCustomProperties(propertiesToSet);
        propertiesToSet.Clear();
    }

    public static bool TryGetStartTime(this Room room, out int timeStap)
    {
        if(room.CustomProperties[KeyStartTime] is int value)
        {
            timeStap = value;
            return true;
        }
        else
        {
            timeStap = 0;
            return false;
        }
    }

    public static void SetStartTime(this Room room, int timestamp)
    {
        propertiesToSet[KeyStartTime] = timestamp;
        room.SetCustomProperties(propertiesToSet);
        propertiesToSet.Clear();
     }
}
