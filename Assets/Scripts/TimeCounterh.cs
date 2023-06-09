using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounterh : MonoBehaviour
{
    //カウントダウン
    public float countdown = 10.0f;

    //時間を表示するText型の変数
    [SerializeField] TextMeshProUGUI timeText; //TextMeshProの変数宣言

    //ポーズしているかどうか
    private bool isPose = false;

    // Update is called once per frame
    void Update()
    {
        //クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            //ポーズ中にクリックされたとき
            if (isPose)
            {
                //ポーズ状態を解除する
                isPose = false;
            }
            //進行中にクリックされたとき
            else
            {
                //ポーズ状態にする
                isPose = true;
            }
        }

        //ポーズ中かどうか
        if (isPose)
        {
            //ポーズ中であることを表示
            timeText.text = "ポーズ中";

            //カウントダウンしない
            return;
        }

        //時間をカウントする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "時間になりました！";
        }
    }
}