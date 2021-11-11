using UnityEngine;
using Photon.Realtime;

//魔法ボールを管理するスクリプト
public class MagicBall : MonoBehaviour
{
    public Player Attacker;
    float ballSpeed = 30f;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
        Destroy(this.gameObject, 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
