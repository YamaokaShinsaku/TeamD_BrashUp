using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiScoop : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //Animatorの取得
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //PlayerがColliderの範囲内に入ったら
        if(other.tag == "Player")
        {
            //character_nearbyをtrueにしてすくう
            animator.SetBool("ScoopTrigger",true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //PlayerがColliderの範囲から出たら
        if (other.tag == "Player")
        {
            //character_nearbyをfalseにしてすくうのをやめる
            animator.SetBool("ScoopTrigger", false);
        }
    }

}
