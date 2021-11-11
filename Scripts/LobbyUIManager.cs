using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

//ロビーのUIを管理するクラス
public class LobbyUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject createRoomPanel;
    [SerializeField]
    Text roomNametext;
    [SerializeField]
    Slider playerNumberSlider;
    [SerializeField]
    Text playerNumberText;

    void Update()
    {
        playerNumberText.text = playerNumberSlider.value.ToString();
    }
    public void OnClick_OpenCreateRoomPanelButton()
    {
        if (createRoomPanel.activeSelf)
        {
            createRoomPanel.SetActive(false);
        }
        else
        {
            createRoomPanel.SetActive(true);
        }
    }
    public void OnClick_CreateRoomButton()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = (byte)playerNumberSlider.value;
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
        {
            { "RoomCreator", PhotonNetwork.NickName}
        };
        roomOptions.CustomRoomPropertiesForLobby = new string[]
        {
            "RoomCreator"
        };
        PhotonNetwork.CreateRoom(roomNametext.text, roomOptions, null);
    }
}
