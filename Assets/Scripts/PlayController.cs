using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // �{�[��
    [SerializeField]
    private Rigidbody ball;

    // �o�[
    [SerializeField]
    private Rigidbody bar;

    // �{�[���̈ړ���
    [SerializeField]
    private float ballShotValue;

    // �o�[�̈ړ���
    [SerializeField]
    private float barMoveValue;

    // ���˃t���O
    private bool isShot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�����������Ƀ{�[������
        if (Input.GetKeyDown(KeyCode.Space) && isShot == false)
        {
            isShot = true;
            ball.velocity = Vector3.up * ballShotValue;
        }

        // �o�[���ړ�����
        var dir = Input.GetAxis("Horizontal");
        bar.velocity = dir * Vector3.right * barMoveValue;
    }
}
