using UnityEngine;

//プレイヤーのステータス情報を管理するクラス
public class LocalValue : MonoBehaviour
{
    static public int currentHp = 100;

    void Start()
    {
        ValueReset();
    }

    static public void ValueReset()
    {
        currentHp = 100;
    }
}
