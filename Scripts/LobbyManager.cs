using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

//ロビーを管理するクラス
public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject roomElementPrefabParent;
    [SerializeField]
    GameObject roomElementPrefab;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        DestroyChildObject(roomElementPrefabParent.transform);
        for (int i = 0; i < roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            GameObject _roomElement = Instantiate(roomElementPrefab);
            _roomElement.transform.SetParent(roomElementPrefabParent.transform);
            _roomElement.GetComponent<RoomElement>().SetRoomInfo(info.Name, info.PlayerCount, roomList[i].MaxPlayers);
        }
    }
    public void DestroyChildObject(Transform parent_trans)
    {
        for (int i = 0; i < parent_trans.childCount; ++i)
        {
            Destroy(parent_trans.GetChild(i).gameObject);
        }
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}
