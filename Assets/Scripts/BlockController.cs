using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // ブロックのプレハブ格納先
    [SerializeField]
    private GameObject blockPrefab;

    // 列の数
    [SerializeField]
    private int row = 3;

    // 行の数
    [SerializeField]
    private int col = 3;

    // 列間
    [SerializeField]
    private float rowSpace = 2f;

    // 行間
    [SerializeField]
    private float colSpace = 1f;

    // 生成したブロックを格納リスト(配列)
    private List<GameObject> blockList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // ブロックのサイズを考慮して列/行のスペースを決める
        var blockScale = blockPrefab.transform.localScale;
        blockScale.x += rowSpace;
        blockScale.y += colSpace;

        // 複数個ブロック作成
        for (var i = 0; i < col; i++)
        {
            for (var j = 0; j < row; j++)
            {
                // グリッド上にプレハブ生成(BlockParentが親)
                // transform：このスクリプトがアタッチされているオブジェクトのTransform
                var block = Instantiate(blockPrefab, transform).transform;

                // 座標を合わせる
                // BlockContoroller の座標がブロックの初期位置
                block.localPosition = new Vector3(blockScale.x * j,
                                                  -blockScale.y * i,
                                                  0f);

                blockList.Add(block.gameObject);
            }
        }
    }

    /// <summary>
    /// リセット処理
    /// ・消えているブロックの再表示
    /// </summary>
    public void OnReset()
    {
        for (var i = 0; i < blockList.Count; i++)
        {
            // オブジェクトのアクティブがオン(true)の時、
            // continue 以下の処理は行わない
            if (blockList[i].activeSelf) continue;

            // アクティブをオン(true)にする
            // ※画面上に再表示
            blockList[i].SetActive(true);
        }
    }
}
