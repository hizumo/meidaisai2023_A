using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを扱う際に必要
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using static PlayerController1;
using TMPro;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.UIElements;
using System;

public class PlayerController1 : MonoBehaviour
{
    // Player1の1マス移動
    float moveSpeed = 5;

    bool isMoving;
    Vector2 input;

    Animator animator;

    //壁判定のLayer
    [SerializeField] LayerMask solidObjects;

    //HPバーの設定
    public UnityEngine.UI.Slider slider;
    //鉱石イベントパネル
    [SerializeField] GameObject panel;
    public Transform target; // 近づくべきオブジェクトのTransform
    //敵イベントパネル
    private mineral mineral1;
    [SerializeField] GameObject panelE;
    public Transform targetE; // 近づくべきオブジェクトのTransform
    private Enemy enemy;
    //スコア表示
    [SerializeField] TextMeshProUGUI Score; //TextMeshProの変数宣言
    public static int score = 0;
    
    /// ポーズ機能の実装
       private bool isPose = false;

    //重さとスピードの関係
    float totalWeight = 0f;
    int itemQuantityS = 0;
    float itemWeight = 0f;   
    int defaultSpeed = 5;
    [SerializeField] bool isShoesUsing;
    private void Awake()
    {
        animator=GetComponent<Animator>();
    }
    void Start()
    {
        slider.value = 100;
        mineral1 = mineral.go;
        enemy = Enemy.go;
        moveSpeed = defaultSpeed - totalWeight;
        //DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        Debug.Log(moveSpeed);
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


            //slider.valueが0以下になったとき
            if (slider.value <= 0)
            {
                SceneManager.LoadScene("Result");
            }

            if (mineral1 == mineral.go)
            {
                if (Vector3.Distance(transform.position, target.position) < 2f)
                {
                    mineral1 = mineral.stop;
                    // 近づいたときの処理を記述する
                    panel.SetActive(true);
                   
                }
            }
            else if (mineral1 == mineral.stop)
            {
                if (Vector3.Distance(transform.position, target.position) > 2f)
                {
                    mineral1 = mineral.go;
                }
            }

            if (enemy == Enemy.go)
            {
                if (Vector3.Distance(transform.position, targetE.position) < 2f)
                {
                    enemy = Enemy.stop;
                    // 近づいたときの処理を記述する
                    panelE.SetActive(true);

                }
            }
            else if (enemy == Enemy.stop)
            {
                if (Vector3.Distance(transform.position, targetE.position) > 2f)
                {
                    enemy = Enemy.go;
                }
            }
          
            Score.text = string.Format("{0} Pt", score);
        }
        
 

        animator.SetBool("isMoving", isMoving);

        if (isPose)
        {
            return;
        }
        //進行中にクリックされたとき
        else
        {
            //HPバーを動かす
            slider.value = slider.value - Time.deltaTime;
        }
      
    }
    public void AdjustSpeed(List<ItemData> itemDataList)
    {
        foreach (ItemData itemData in itemDataList)
        {
            itemQuantityS = itemData.GetItemQuantity();
            itemWeight = itemData.GetItemWeight();
            totalWeight += itemQuantityS * itemWeight;
        }
        //moveSpeed = defaultSpeed + 2 * Convert.ToInt32(isShoesUsing) - totalWeight;
        moveSpeed = defaultSpeed  - totalWeight;
    }

    //ポーズ中にクリックされたとき
    public void InventoryClick()
    {
        isPose = true;
    }

    public void GameClick()
    {
        isPose = false;
    }
    public void OnClick2()
    {     
            StartCoroutine(ShowMsg2());       
    }
    IEnumerator ShowMsg2()
    {
        moveSpeed = moveSpeed * 3/2;
        yield return new WaitForSeconds(10);
        moveSpeed = moveSpeed * 2/3;
    }
    public void OnClick3()
    {
        slider.value = slider.value + 10;
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

    public enum mineral
    {
        go,
        stop,     
    }
    public enum Enemy
    {
        go,
        stop,
    }
}
