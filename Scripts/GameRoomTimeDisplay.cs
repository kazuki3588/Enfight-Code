using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

//サーバーの時間を管理するクラス
public class GameRoomTimeDisplay : MonoBehaviour
{
    Text timeText;
    const float MAXTIME = 200f;
    float elapsedTime = 300;
    void Start()
    {
        timeText = GetComponent<Text>();   
    }

    private void Update()
    {
        if (!PhotonNetwork.InRoom) return;
        if (!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) return;
        elapsedTime = Mathf.Max(0f, unchecked(PhotonNetwork.ServerTimestamp - timestamp) / 1000f);
        elapsedTime = Mathf.Clamp(MAXTIME - (float)elapsedTime,0,MAXTIME);
        timeText.text = elapsedTime.ToString("f1");
    }

    public float SetTime()
    {
        return elapsedTime;
    }
}
