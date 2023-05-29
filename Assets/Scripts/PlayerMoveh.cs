using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;//UIを扱う際に必要

public class PlayerMoveh : MonoBehaviour
{
    public Slider slider;
    private float speed = 3.0f;

    //カウントダウン
    public float countdown = 100.0f;

    //時間を表示するText型の変数
    [SerializeField] TextMeshProUGUI timeText; //TextMeshProの変数宣言

    //ポーズしているかどうか
    private bool isPose = false;

    void Start()
    {
        slider.value = 100;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.position = new Vector3(
          transform.position.x + moveX,
          transform.position.y,
          transform.position.z + moveZ
        );
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
        //HPバーを動かす
        slider.value = slider.value - Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "時間になりました！";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "PointDown")
        {
            slider.value = slider.value - 10.0f;
        }

        if (other.gameObject.name == "PointUp")
        {
            slider.value = slider.value - 3.0f;
        }

    }
}