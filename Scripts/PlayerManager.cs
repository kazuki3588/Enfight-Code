using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

//ローカルプレイヤーを管理するクラス
public class PlayerManager : MonoBehaviourPunCallbacks,IPunObservable
{
    public int Hp;

    void Update()
    {
        if (!photonView.IsMine) return;
        Hp = LocalValue.currentHp;
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Hp);
        }
        else
        {
            Hp = (int)stream.ReceiveNext();
        }
    }
   
}
