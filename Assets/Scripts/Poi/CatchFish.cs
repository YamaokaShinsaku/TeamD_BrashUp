using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public GameObject[] Players;        // player
    public Transform poiUpPosition;     // プレイヤーを固定する座標

    private void OnTriggerStay(Collider other)
    {
        // player１がいるとき
        if(other.gameObject == Players[0])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            // プレイヤーの座座標をポイの上に固定する
            Players[0].transform.position = poiUpPosition.transform.position;
        }
        // player２がいるとき
        if (other.gameObject == Players[1])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            // プレイヤーの座座標をポイの上に固定する
            Players[1].transform.position = poiUpPosition.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // player１が出た時
        if (other.gameObject == Players[0])
        {
            //Debug.Log(other.gameObject.name + "Exit");
        }
        // player２が出た時
        if (other.gameObject == Players[1])
        {
            //Debug.Log(other.gameObject.name + "Exit");
        }
    }
}
