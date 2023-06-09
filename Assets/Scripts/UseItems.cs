using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UseItems : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI confirmText; //TextMeshProの変数宣言
    public Button yesButton;
    public Button noButton;
    [SerializeField] GameObject panelY;
    //HPバーの設定
    //public Slider slider;
    public bool isItemUsed = false;
    public bool isButtonClicked = false;
    public PlayerController1 playercontroller;
    public GameObject objb;

    private void Start()
    {
        playercontroller = FindObjectOfType<PlayerController1>();
        objb = GameObject.Find("InventoryUI/Panel/BackButton");

    }
    private void Update()
    {

    }
    /*/ メッセージを表示する
    public void showMsg(string _confirmText)
    {
        showMsg(_confirmText, "はい", "いいえ");
    }
    public void showMsg(string _confirmText, string _yesButtonText, string _noButtonText)
    {
        // 質問文を表示するテキストに値を設定
        confirmText.text = _confirmText;
        // はいボタンのラベルを設定
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = _yesButtonText;
        // いいえボタンのラベルを設定
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = _noButtonText;
        // アクティブにする（表示する）
        gameObject.SetActive(true);
        // ボタンのアクションを設定

    }*/

    // はいボタンの処理
    public void onYesClick()
    {
        /* InventoryManager inventory = GetComponent<InventoryManager>();
        if (inventory != null)
        {
            Debug.Log("Ready");
        }
        else
        {
            Debug.Log("Failed");
        }*/
        StartCoroutine("YesClick");
        if (InventoryManager.Item2 == true)
        {
            
            playercontroller.OnClick2();
            
        }
        else
        {
            
            playercontroller.OnClick3();
            
        }
        
        objb.gameObject.SetActive(true);

    }
  
    IEnumerator YesClick()
    {
        isItemUsed = true;
        panelY.SetActive(true);

        //Question という名前のオブジェクトを取得
        GameObject objq = GameObject.Find("Question");
        // 指定したオブジェクトを削除
        objq.gameObject.SetActive(false);
        //YesButton という名前のオブジェクトを取得
        GameObject objy = GameObject.Find("YesButton");
        // 指定したオブジェクトを削除
        objy.gameObject.SetActive(false);
        //NoButton という名前のオブジェクトを取得
        GameObject objn = GameObject.Find("NoButton");
        // 指定したオブジェクトを削除
        objn.gameObject.SetActive(false);
        //slider.value -= 10;
        //スコア加算
        //PlayerController1.score += 10;

        //1秒停止
        yield return new WaitForSeconds(1);
        panelY.SetActive(false);

        objq.gameObject.SetActive(true);
        objy.gameObject.SetActive(true);
        objn.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

        isButtonClicked = true;
    }

    // いいえボタンの処理
    public void onNoClick()
    {    
        isItemUsed = false;
        isButtonClicked = true;
        // 非アクティブにする
        gameObject.SetActive(false);
        
        objb.gameObject.SetActive(true);

    }
}

