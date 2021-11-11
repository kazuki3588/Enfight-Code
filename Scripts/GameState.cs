using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityChan;

//ゲームの状態を管理するクラス
public class GameState : MonoBehaviour
{
    float JugeTime;
    GameRoomTimeDisplay timeDisplay;
    Text stateText;
    bool finish = false;
    public bool Finish
    {
        get { return finish; }
    }
    void Start()
    {
        timeDisplay = GameObject.Find("TimeText").GetComponent<GameRoomTimeDisplay>();
        stateText = GetComponent<Text>();
    }

    private void Update()
    {
        CheackTime();
        CheckGameState();
    }

    void CheackTime()
    {
        JugeTime = timeDisplay.SetTime();
        finish = JugeTime == 0 ? true : false;
    }

    void CheckGameState()
    {
        if (!finish) return;
        var players = PhotonNetwork.PlayerList;
        Array.Sort(players, (p1, p2) =>
         {
             int diff = p1.DeadGetScore() - p2.DeadGetScore();
             if (diff != 0)
             {
                 return diff;
             }
             return p1.ActorNumber - p2.ActorNumber;
         }
        );

        var winPlayer = players[0];
        if(PhotonNetwork.LocalPlayer == winPlayer)
        {
            stateText.text = "Win!!";
            StartCoroutine("BackScreen");
        }
        else
        {
            stateText.color = new Color(255,0,0,255);
            stateText.text = "Lose";
            StartCoroutine("BackScreen");
        }
    }

    IEnumerator BackScreen()
    {
        yield return new WaitForSeconds(10f);
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("LoginScene");
    }
}
