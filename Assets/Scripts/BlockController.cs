using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // �u���b�N�̃v���n�u�i�[��
    [SerializeField]
    private GameObject blockPrefab;

    // ��̐�
    [SerializeField]
    private int row = 3;

    // �s�̐�
    [SerializeField]
    private int col = 3;

    // ���
    [SerializeField]
    private float rowSpace = 2f;

    // �s��
    [SerializeField]
    private float lowSpace = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // �u���b�N�̃T�C�Y���l�����ė�/�s�̃X�y�[�X�����߂�
        var blockScale = blockPrefab.transform.localScale;
        blockScale.x += rowSpace;
        blockScale.y += lowSpace;

        // �����u���b�N�쐬
        for (var i = 0; i < col; i++)
        {
            for (var j = 0; j < row; j++)
            {
                // �O���b�h��Ƀv���n�u����(BlockParent���e)
                // transform�F���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��Transform
                var block = Instantiate(blockPrefab, transform).transform;

                // ���W�����킹��
                block.localPosition = new Vector3(-blockScale.x + blockScale.x * j,
                                                  -blockScale.y + blockScale.y * i,
                                                  0f);
            }
        }
    }
}
