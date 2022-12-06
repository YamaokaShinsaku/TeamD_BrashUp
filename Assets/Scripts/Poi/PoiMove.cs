using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiMove : MonoBehaviour
{
    [SerializeField]
    public GameObject target;      // 追従するオブジェクト

    [SerializeField]
    private float speed;            // 移動速度

    private void Update()
    {
        // target に向かって移動する
        this.transform.position =
            Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * speed);
    }

}
