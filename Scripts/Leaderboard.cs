using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

//死んだ回数を表示するクラス
public class Leaderboard : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Text DeadScoreText = default;

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (!targetPlayer.IsLocal) return;
        DeadScoreText.text = "Dead:" + targetPlayer.DeadGetScore();
    }


}
