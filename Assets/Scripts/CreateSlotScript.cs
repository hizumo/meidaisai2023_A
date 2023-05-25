using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class CreateSlotScript : MonoBehaviour
{
    //�@�A�C�e�����̃X���b�g�v���n�u
    [SerializeField] private GameObject itemSlot;
    //�@��l���̃X�e�[�^�X
    //[SerializeField] MyStatus myStatus;
    //�@�A�C�e���f�[�^�x�[�X
    [SerializeField] private ItemDataBase itemDataBase;

    //�@�A�N�e�B�u�ɂȂ�����
    void Start()
    {
        //�@�A�C�e���f�[�^�x�[�X�ɓo�^����Ă���A�C�e���p�̃X���b�g��S����
        CreateSlot(itemDataBase.GetItemDataList());
    }

    //�@�A�C�e���X���b�g�̐���
    public void CreateSlot(List<ItemData> itemList)
    {
        int i = 0;
        foreach (var item in itemList) 
        {
            //�@�X���b�g�̃C���X�^���X��
            var instanceSlot = Instantiate<GameObject>(itemSlot, transform);
            //�@�X���b�g�Q�[���I�u�W�F�N�g�̖��O��ݒ�
            instanceSlot.name = "ItemSlot" + i++;
            //�@Scale��ݒ肵�Ȃ���0�ɂȂ�̂Őݒ�
            instanceSlot.transform.localScale = new Vector3 (1f, 1f, 1f);
            //�@�A�C�e�������X���b�g��ProcessingSlot�ɐݒ肷��
            instanceSlot.GetComponent<ProcessingSlot>().SetItemData(item);
        }
    }
}
