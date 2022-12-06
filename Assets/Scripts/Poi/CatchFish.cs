using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public GameObject Player;
    public Transform poiUpPosition;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == Player)
        {
            //Debug.Log(other.gameObject.name + "Stay");

            // �v���C���[�̍����W���|�C�̏�ɌŒ肷��
            Player.transform.position = poiUpPosition.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        {
            //Debug.Log(other.gameObject.name + "Exit");
        }
    }
}
