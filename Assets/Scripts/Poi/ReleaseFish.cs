using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseFish : MonoBehaviour
{
    public GameObject[] Players;        // player

    public bool isChatching;    // �߂܂��Ă��邩�ǂ���

    /// �A�Ŋ֘A ///
    [SerializeField]
    private float interval = 0.3f;    // �A�Œ��̃N���b�N�Ԋu

    [SerializeField]
    private int startCount = 3;      // ���N���b�N�ڂ���A�Œ��ɐ؂�ւ��邩

    [SerializeField]
    private int maxClickCount;     // �N���b�N���̎w���

    [SerializeField]
    private int clickCount;        // �N���b�N��
    [SerializeField]
    private int clickCountRecord;  // �N���b�N���̋L�^
    [SerializeField]
    private bool isCounting;       // �N���b�N�𐔂��Ă��邩�ǂ���
    [SerializeField]
    private bool isMashing;        // �A�ł��Ă��邩�ǂ���
    [SerializeField]
    private float second;          // �N���b�N�Ԃ̕b��

    // Start is called before the first frame update
    void Start()
    {
        isChatching = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �߂܂��Ă���Ƃ�
        if (isChatching)
        {
            // ���N���b�N���ꂽ�Ƃ�
            if(Input.GetMouseButtonDown(0))
            {
                // �t���O�𗧂Ă�
                isCounting = true;
                // �b�������Z�b�g
                second = 0.0f;
                // �N���b�N����+1
                clickCount++;
            }

            // �����Ă���Ƃ�
            if(isCounting)
            {
                // �b�����J�E���g
                second += Time.deltaTime;

                // ���Ԑ؂�̎�
                if(second > interval)
                {
                    // �t���O��܂�
                    isCounting = false;
                    // �A�ŏ�Ԃ�����
                    isMashing = false;

                    // �N���b�N�����L�^
                    clickCountRecord = clickCount;
                    // �N���b�N�������Z�b�g
                    clickCount = 0;
                }
            }
            // �����Ă��邪�A�Œ��ł͂Ȃ��Ƃ�
            else if(!isMashing)
            {
                // �w��񐔈ȏ�N���b�N���ꂽ�Ƃ�
                if(clickCount >= startCount)
                {
                    // �A�ŏ�Ԃɂ���
                    isMashing = true;
                }
            }
        }

        // ������ꂽ��
        if(!isChatching)
        {
            // ����������
            isCounting = false;
            isMashing = false;
            clickCount = 0;
            second = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // player�P������Ƃ�
        if (other.gameObject == Players[0])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            isChatching = true;
        }
        // player�Q������Ƃ�
        if (other.gameObject == Players[1])
        {
            //Debug.Log(other.gameObject.name + "Stay");

            isChatching = true;
        }

        // �w��񐔘A�ł�����
        if(clickCount > maxClickCount)
        {
            isChatching = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
