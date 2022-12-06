using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField]
    private float deltaTime;    // �o�ߎ���
    [SerializeField]
    private float vectorX;      // �����_��X���W
    [SerializeField]
    private float vectorZ;      // �����_���y���W

    const float vectorY = 5.0f;      // Y���W�͌Œ�

    [SerializeField]
    public float restTime;

    // ��������͈͂̍��W�����I�u�W�F�N�g���擾
    [SerializeField]
    private Transform rangeXMin;
    [SerializeField]
    private Transform rangeXMax;
    [SerializeField]
    private Transform rangeZMin;
    [SerializeField]
    private Transform rangeZMax;

    // Start is called before the first frame update
    void Start()
    {
        deltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime -= Time.deltaTime;

        if (deltaTime <= 0.0f)
        {
            // �����_���Ȓl���擾
            vectorX = Random.Range(rangeXMin.position.x, rangeXMax.position.x);
            vectorZ = Random.Range(rangeZMin.position.z, rangeZMax.position.z);

            // ���W�X�V
            this.transform.position = new Vector3(vectorX, vectorY, vectorZ);

            // �o�ߎ��Ԃ����Z�b�g
            deltaTime = restTime;
        }
    }
}
