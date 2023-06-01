using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class YesNoMsg : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI confirmText; //TextMeshProの変数宣言
    public Button yesButton;
    public Button noButton;
    [SerializeField] GameObject panelY;


    // メッセージを表示する
    public void showMsg(string _confirmText)
    {
        showMsg(_confirmText, "はい", "いいえ");
    }
    public void showMsg(string _confirmText, string _yesButtonText, string _noButtonText)
    {
        // 質問文を表示するテキストに値を設定
        confirmText.text = _confirmText;
        // はいボタンのラベルを設定
        yesButton.GetComponentInChildren<Text>().text = _yesButtonText;
        // いいえボタンのラベルを設定
        noButton.GetComponentInChildren<Text>().text = _noButtonText;
        // アクティブにする（表示する）
        gameObject.SetActive(true);
        // ボタンのアクションを設定

    }

    // はいボタンの処理
    public void onYesClick()
    {            
        StartCoroutine("YesClick");            
    }
    IEnumerator YesClick()
    {
        panelY.SetActive(true);

        //Question という名前のオブジェクトを取得
        GameObject objq = GameObject.Find("Question");
        // 指定したオブジェクトを削除
        Destroy(objq);
        //Question という名前のオブジェクトを取得
        GameObject objy = GameObject.Find("YesButton");
        // 指定したオブジェクトを削除
        Destroy(objy);
        //Question という名前のオブジェクトを取得
        GameObject objn = GameObject.Find("NoButton");
        // 指定したオブジェクトを削除
        Destroy(objn);

        //3秒停止
        yield return new WaitForSeconds(1);
        panelY.SetActive(false);
        this.gameObject.SetActive(false);
    }

    // いいえボタンの処理
    public void onNoClick()
    {
        // 非アクティブにする
        gameObject.SetActive(false);
    }
}

