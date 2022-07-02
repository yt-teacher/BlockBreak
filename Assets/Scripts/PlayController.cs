using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // ボール
    [SerializeField]
    private Ball ball;

    // バー
    [SerializeField]
    private Bar bar;

    // ブロックコントローラー
    [SerializeField]
    private BlockController blockController;

    // ボールの移動量
    [SerializeField]
    private float ballShotValue;

    // バーの移動量
    [SerializeField]
    private float barMoveValue;

    // 発射フラグ
    private bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        // ボールの初期化
        ball.OnInit(ballShotValue);

        // ボールがリセットされる
        // エリアに衝突した際に呼ばれる関数を登録
        ball.TriggerBall += TriggerBall;

        // バーの初期化
        bar.OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押した時にボール発射
        if (Input.GetKeyDown(KeyCode.Space) && isShot == false)
        {
            isShot = true;
            ball.SetSpeed(ballShotValue);
        }

        // Rキーを押したときにリセット
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

        // バーの移動処理
        bar.OnMove(barMoveValue);
    }

    /// <summary>
    /// ゲームのリセット
    /// ・ボールのリセット
    /// ・ブロックのリセット
    /// </summary>
    private void ResetGame()
    {
        // ボールを発射できるようにする
        isShot = false;
        // ボールのリセット
        ball.OnReset();

        // バーのリセット
        bar.OnReset();

        // ブロックのリセット
        blockController.OnReset();
    }

    /// <summary>
    /// ボールがリセットされる
    /// エリアに衝突した際に呼ばれる関数
    /// </summary>
    private void TriggerBall()
    {
        ResetGame();
    }
}
