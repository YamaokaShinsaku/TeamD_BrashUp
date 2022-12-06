using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public GameObject[] Players;        // player
    public Transform poiUpPosition;     // �v���C���[���Œ肷����W

    private void OnTriggerStay(Collider other)
    {
        // player�P������Ƃ�
        if(other.gameObject == Players[0])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            // �v���C���[�̍����W���|�C�̏�ɌŒ肷��
            Players[0].transform.position = poiUpPosition.transform.position;
        }
        // player�Q������Ƃ�
        if (other.gameObject == Players[1])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            // �v���C���[�̍����W���|�C�̏�ɌŒ肷��
            Players[1].transform.position = poiUpPosition.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // player�P���o����
        if (other.gameObject == Players[0])
        {
            //Debug.Log(other.gameObject.name + "Exit");
        }
        // player�Q���o����
        if (other.gameObject == Players[1])
        {
            //Debug.Log(other.gameObject.name + "Exit");
        }
    }
}
