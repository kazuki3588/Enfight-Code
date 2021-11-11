using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//ネットに接続するクラス
public class Net : MonoBehaviourPunCallbacks
{
    public void OnOprationButton()
    {
        SceneManager.LoadScene("OparationScene");
    }
    public void OnConnectNetBotton()
    {
        if (PhotonNetwork.IsConnected) return;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }
}

