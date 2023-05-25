using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounterh : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown = 10.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    [SerializeField] TextMeshProUGUI timeText; //TextMeshPro�̕ϐ��錾

    //�|�[�Y���Ă��邩�ǂ���
    private bool isPose = false;

    // Update is called once per frame
    void Update()
    {
        //�N���b�N���ꂽ�Ƃ�
        if (Input.GetMouseButtonDown(0))
        {
            //�|�[�Y���ɃN���b�N���ꂽ�Ƃ�
            if (isPose)
            {
                //�|�[�Y��Ԃ���������
                isPose = false;
            }
            //�i�s���ɃN���b�N���ꂽ�Ƃ�
            else
            {
                //�|�[�Y��Ԃɂ���
                isPose = true;
            }
        }

        //�|�[�Y�����ǂ���
        if (isPose)
        {
            //�|�[�Y���ł��邱�Ƃ�\��
            timeText.text = "�|�[�Y��";

            //�J�E���g�_�E�����Ȃ�
            return;
        }

        //���Ԃ��J�E���g����
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countdown.ToString("f1") + "�b";

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            timeText.text = "���ԂɂȂ�܂����I";
        }
    }
}