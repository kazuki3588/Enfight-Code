using UnityEngine;
using Photon.Pun;

//名前をセットするクラス
public class NameController : MonoBehaviour
{
    public void SetPlayerName(string value)
    {
        PhotonNetwork.LocalPlayer.NickName = value;
    }
}
