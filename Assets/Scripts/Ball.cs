using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // �������g
    [SerializeField]
    private Rigidbody body;

    // �����ʒu
    private Vector3 initPos;

    // �ō����x
    private float maxSpeed;

    // �{�[�������Z�b�g�����
    // �G���A�ɗ����ۂɌĂ΂��֐�(�f���Q�[�g)
    public System.Action TriggerBall;

    /// <summary>
    /// ������
    /// �E�{�[���̏����ʒu
    /// �E�{�[���̍ō����x�̐ݒ�Ȃ�
    /// </summary>
    public void OnInit(float speed)
    {
        initPos = transform.localPosition;
        maxSpeed = speed;
    }

    /// <summary>
    /// ���Z�b�g
    /// �E�{�[���������ʒu�Ɉړ�������
    /// �E�{�[���̑��x��0�ɂ���Ȃ�
    /// </summary>
    public void OnReset()
    {
        transform.localPosition = initPos;
        body.velocity = Vector3.zero;
    }

    /// <summary>
    /// �{�[���̈ړ��ʂ��Z�b�g����
    /// </summary>
    public void SetSpeed(float speed)
    {
        // ���E�΂�(��)�������擾
        var dir = Vector3.zero;
        dir.x = Random.Range(-0.5f, 0.5f);
        dir.y = 1f;
        dir.Normalize();

        body.velocity = dir * speed;
    }

    // ����������͎���

    /// <summary>
    /// ���������̍X�V
    /// </summary>
    public void OnFixedUpdate()
    {
        var speed = body.velocity.magnitude;
        if (speed >= maxSpeed)
        {
            // ���x����
        }
    }

    /// <summary>
    /// �{�[�����Փ˂����I�u�W�F�N�g���擾�ł���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���擾
        var obj = collision?.gameObject;

        // �Փ˂����I�u�W�F�N�g�̃^�O������̂��̂ł���΁A
        // �e������������
        if (obj != null && obj.tag == "Block")
        {
            // �I�u�W�F�N�g�폜
            //Destroy(obj); // �R�X�g��

            // �I�u�W�F�N�g���q�G�����L�[�ォ�����
            // �ҏW�ł��Ȃ�/�����Ȃ��悤�Ȋ���
            obj.SetActive(false);   // �R�X�g��
        }
    }

    /// <summary>
    /// ���������͂��Ȃ����A�Փ˔�����s������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // �Փ˂����I�u�W�F�N�g���擾
        var obj = other?.gameObject;

        // �Փ˂����I�u�W�F�N�g�̃^�O������̂��̂ł���΁A
        // �e������������
        if (obj != null && obj.tag == "Reset")
        {
            // �{�[���݂̂����Z�b�g
            OnReset();

            // ���̕ϐ��ɓo�^���ꂽ�֐����Ăяo��
            TriggerBall?.Invoke();
        }
    }
}
