using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityChan;
using System.Collections.Generic;

//ゲームシーンを管理するクラス
public class GameMana : MonoBehaviourPunCallbacks
{
    Dictionary<int, Vector3> position = new Dictionary<int, Vector3>()
    {
        {1, new Vector3(66,0,58)},
        {2, new Vector3(25,0,25)},
        {3, new Vector3(70,0,15)},
        {4, new Vector3(20,0,60)}
    };
    const string localPlayer = "LocalPlayer";
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("LoginScene");
            return;
        }
        PhotonNetwork.Instantiate(localPlayer, position[Random.Range(1,5)], Quaternion.identity, 0);

        var mainCamera = GameObject.FindWithTag("MainCamera");
        mainCamera.GetComponent<ThirdPersonCamera>().enabled = true;
        if(PhotonNetwork.CurrentRoom.MaxPlayers == 1)
        {
            PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        }
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount != PhotonNetwork.CurrentRoom.MaxPlayers) return;
        PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
    }
}
