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
    [SerializeField] TextMeshProUGUI confirmText; //TextMeshPro�̕ϐ��錾
    public Button yesButton;
    public Button noButton;
    [SerializeField] GameObject panelY;
    //HP�o�[�̐ݒ�
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
    /*/ ���b�Z�[�W��\������
    public void showMsg(string _confirmText)
    {
        showMsg(_confirmText, "�͂�", "������");
    }
    public void showMsg(string _confirmText, string _yesButtonText, string _noButtonText)
    {
        // ���╶��\������e�L�X�g�ɒl��ݒ�
        confirmText.text = _confirmText;
        // �͂��{�^���̃��x����ݒ�
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = _yesButtonText;
        // �������{�^���̃��x����ݒ�
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = _noButtonText;
        // �A�N�e�B�u�ɂ���i�\������j
        gameObject.SetActive(true);
        // �{�^���̃A�N�V������ݒ�

    }*/

    // �͂��{�^���̏���
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

        //Question �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject objq = GameObject.Find("Question");
        // �w�肵���I�u�W�F�N�g���폜
        objq.gameObject.SetActive(false);
        //YesButton �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject objy = GameObject.Find("YesButton");
        // �w�肵���I�u�W�F�N�g���폜
        objy.gameObject.SetActive(false);
        //NoButton �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject objn = GameObject.Find("NoButton");
        // �w�肵���I�u�W�F�N�g���폜
        objn.gameObject.SetActive(false);
        //slider.value -= 10;
        //�X�R�A���Z
        //PlayerController1.score += 10;

        //1�b��~
        yield return new WaitForSeconds(1);
        panelY.SetActive(false);

        objq.gameObject.SetActive(true);
        objy.gameObject.SetActive(true);
        objn.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

        isButtonClicked = true;
    }

    // �������{�^���̏���
    public void onNoClick()
    {    
        isItemUsed = false;
        isButtonClicked = true;
        // ��A�N�e�B�u�ɂ���
        gameObject.SetActive(false);
        
        objb.gameObject.SetActive(true);

    }
}

