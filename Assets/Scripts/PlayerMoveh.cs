using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;//UI�������ۂɕK�v

public class PlayerMoveh : MonoBehaviour
{
    public Slider slider;
    private float speed = 3.0f;

    //�J�E���g�_�E��
    public float countdown = 100.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    [SerializeField] TextMeshProUGUI timeText; //TextMeshPro�̕ϐ��錾

    //�|�[�Y���Ă��邩�ǂ���
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
        //HP�o�[�𓮂���
        slider.value = slider.value - Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countdown.ToString("f1") + "�b";

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            timeText.text = "���ԂɂȂ�܂����I";
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