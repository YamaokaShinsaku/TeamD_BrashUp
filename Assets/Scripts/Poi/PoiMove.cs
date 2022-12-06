using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiMove : MonoBehaviour
{
    [SerializeField]
    public GameObject target;      // �Ǐ]����I�u�W�F�N�g

    [SerializeField]
    private float speed;            // �ړ����x

    private void Update()
    {
        // target �Ɍ������Ĉړ�����
        this.transform.position =
            Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * speed);
    }

}
