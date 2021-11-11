using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

//ルームを表示するクラス
public class RoomElement : MonoBehaviour
{
    [SerializeField]
    Text roomName;
    [SerializeField]
    Text numberOfPeople;

    string roomNameHouse;

    public void SetRoomInfo(string _roomName, int _numberOfPeople, int _maxPlayer)
    {
        roomNameHouse = _roomName;
        roomName.text = "部屋名:" + _roomName;
        numberOfPeople.text = "人数:" + _numberOfPeople + "/" + _maxPlayer;
    }
    public void OnJoinRoomButton()
    {
        PhotonNetwork.JoinRoom(roomNameHouse);
    }
}
