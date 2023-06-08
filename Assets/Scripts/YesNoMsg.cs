using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YesNoMsg : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI confirmText; //TextMeshProの変数宣言
    public Button yesButton;
    public Button noButton;
    [SerializeField] GameObject panelY;
    //HPバーの設定
    public Slider slider;
     

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
        objq.gameObject.SetActive(false);
        //Question という名前のオブジェクトを取得
        GameObject objy = GameObject.Find("YesButton");
        // 指定したオブジェクトを削除
        objy.gameObject.SetActive(false);
        //Question という名前のオブジェクトを取得
        GameObject objn = GameObject.Find("NoButton");
        // 指定したオブジェクトを削除
        objn.gameObject.SetActive(false);
        slider.value -= 10;
        //スコア加算
        PlayerController1.score += 10;

        //3秒停止
        yield return new WaitForSeconds(1);
        panelY.SetActive(false);

        objq.gameObject.SetActive(true);
        objy.gameObject.SetActive(true);
        objn.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

    }
    public void onYesClickE()
    {
        StartCoroutine("YesClickE");
    }
    IEnumerator YesClickE()
    {
        panelY.SetActive(true);

        //Question という名前のオブジェクトを取得
        GameObject objq = GameObject.Find("QuestionE");
        // 指定したオブジェクトを削除
        objq.gameObject.SetActive(false);
        //Question という名前のオブジェクトを取得
        GameObject objy = GameObject.Find("YesButtonE");
        // 指定したオブジェクトを削除
        objy.gameObject.SetActive(false);
        //Question という名前のオブジェクトを取得
        GameObject objn = GameObject.Find("NoButtonE");
        // 指定したオブジェクトを削除
        objn.gameObject.SetActive(false);
        slider.value -= 20;
        //スコア加算
        PlayerController1.score += 20;

        //3秒停止
        yield return new WaitForSeconds(1);
        panelY.SetActive(false);

        objq.gameObject.SetActive(true);
        objy.gameObject.SetActive(true);
        objn.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

    }
    // いいえボタンの処理
    public void onNoClick()
    {
        // 非アクティブにする
        gameObject.SetActive(false);
    }
}

