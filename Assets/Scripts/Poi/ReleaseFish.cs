using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseFish : MonoBehaviour
{
    public GameObject[] Players;        // player

    public bool isChatching;    // 捕まえているかどうか

    /// 連打関連 ///
    [SerializeField]
    private float interval = 0.3f;    // 連打中のクリック間隔

    [SerializeField]
    private int startCount = 3;      // 何クリック目から連打中に切り替えるか

    [SerializeField]
    private int maxClickCount;     // クリック数の指定回数

    [SerializeField]
    private int clickCount;        // クリック数
    [SerializeField]
    private int clickCountRecord;  // クリック数の記録
    [SerializeField]
    private bool isCounting;       // クリックを数えているかどうか
    [SerializeField]
    private bool isMashing;        // 連打しているかどうか
    [SerializeField]
    private float second;          // クリック間の秒数

    // Start is called before the first frame update
    void Start()
    {
        isChatching = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 捕まえているとき
        if (isChatching)
        {
            // 左クリックされたとき
            if(Input.GetMouseButtonDown(0))
            {
                // フラグを立てる
                isCounting = true;
                // 秒数をリセット
                second = 0.0f;
                // クリック数を+1
                clickCount++;
            }

            // 数えているとき
            if(isCounting)
            {
                // 秒数をカウント
                second += Time.deltaTime;

                // 時間切れの時
                if(second > interval)
                {
                    // フラグを折る
                    isCounting = false;
                    // 連打状態を解除
                    isMashing = false;

                    // クリック数を記録
                    clickCountRecord = clickCount;
                    // クリック数をリセット
                    clickCount = 0;
                }
            }
            // 数えているが連打中ではないとき
            else if(!isMashing)
            {
                // 指定回数以上クリックされたとき
                if(clickCount >= startCount)
                {
                    // 連打状態にする
                    isMashing = true;
                }
            }
        }

        // 逃げられたら
        if(!isChatching)
        {
            // 初期化する
            isCounting = false;
            isMashing = false;
            clickCount = 0;
            second = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // player１がいるとき
        if (other.gameObject == Players[0])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            isChatching = true;
        }
        // player２がいるとき
        if (other.gameObject == Players[1])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            isChatching = true;
        }

        // 指定回数連打したら
        if(clickCount > maxClickCount)
        {
            isChatching = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
