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
    [SerializeField] TextMeshProUGUI confirmText; //TextMeshPro�̕ϐ��錾
    public Button yesButton;
    public Button noButton;
    [SerializeField] GameObject panelY;


    // ���b�Z�[�W��\������
    public void showMsg(string _confirmText)
    {
        showMsg(_confirmText, "�͂�", "������");
    }
    public void showMsg(string _confirmText, string _yesButtonText, string _noButtonText)
    {
        // ���╶��\������e�L�X�g�ɒl��ݒ�
        confirmText.text = _confirmText;
        // �͂��{�^���̃��x����ݒ�
        yesButton.GetComponentInChildren<Text>().text = _yesButtonText;
        // �������{�^���̃��x����ݒ�
        noButton.GetComponentInChildren<Text>().text = _noButtonText;
        // �A�N�e�B�u�ɂ���i�\������j
        gameObject.SetActive(true);
        // �{�^���̃A�N�V������ݒ�

    }

    // �͂��{�^���̏���
    public void onYesClick()
    {            
        StartCoroutine("YesClick");            
    }
    IEnumerator YesClick()
    {
        panelY.SetActive(true);

        //Question �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject objq = GameObject.Find("Question");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(objq);
        //Question �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject objy = GameObject.Find("YesButton");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(objy);
        //Question �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject objn = GameObject.Find("NoButton");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(objn);

        //3�b��~
        yield return new WaitForSeconds(1);
        panelY.SetActive(false);
        this.gameObject.SetActive(false);
    }

    // �������{�^���̏���
    public void onNoClick()
    {
        // ��A�N�e�B�u�ɂ���
        gameObject.SetActive(false);
    }
}

