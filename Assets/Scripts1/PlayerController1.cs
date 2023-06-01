using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを扱う際に必要
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    // Player1の1マス移動
    [SerializeField] float moveSpeed;

    bool isMoving;
    Vector2 input;

    Animator animator;

    //壁判定のLayer
    [SerializeField] LayerMask solidObjects;

    //HPバーの設定
    public Slider slider;
    //カウントダウン
    public float countdown = 100.0f;

    private void Awake()
    {
        animator=GetComponent<Animator>();
    }
    void Start()
    {
        slider.value = 100;
    }
    void Update()
    {
        // 動いていない時
        if (!isMoving)
        {
            // キーボード入力を受け付ける
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

             // 斜め移動禁止:横方向の入力があれば, 縦は0にする
            if (input.x != 0)
            {
                input.y = 0;
            }

            // 入力があったら
            if (input != Vector2.zero)
            {
                // 入力があったときに向きを変える
                animator.SetFloat("MoveX",input.x);
                animator.SetFloat("MoveY",input.y);
                Vector2 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));   
                }
            }

            //時間をカウントする
            countdown -= Time.deltaTime;
            //HPバーを動かす
            slider.value = slider.value - Time.deltaTime;
         
            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                SceneManager.LoadScene("Result");
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        // targetPosと現在のpisitionの差がある間は、MoveTowardsでtargetPosに近く
        while ((targetPos- transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    // targetPosに移動可能かを調べる関数
    bool IsWalkable(Vector2 targetPos)
    {
        // targetPosに半径0.2fの円のRayを飛ばして、ぶつからなかったらfalse
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjects) == false;
    }
}