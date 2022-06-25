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
    private Rigidbody bar;

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
            // ボールのリセット
            ball.OnReset();
            // ブロックのリセット
            blockController.OnReset();
        }

        // バーを移動する
        var dir = Input.GetAxis("Horizontal");
        bar.velocity = dir * Vector3.right * barMoveValue;
    }
}
