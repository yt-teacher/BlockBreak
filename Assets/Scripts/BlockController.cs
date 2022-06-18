using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // �u���b�N�̃v���n�u�i�[��
    [SerializeField]
    private GameObject blockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // �����u���b�N�쐬
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                // �O���b�h��Ƀv���n�u����(BlockParent���e)
                // transform�F���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��Transform
                var block = Instantiate(blockPrefab, transform).transform;

                // ���W�����킹��
                block.localPosition = new Vector3(-5f + 5f * j, -2f + 2f * i, 0f);
            }
        }
    }
}
