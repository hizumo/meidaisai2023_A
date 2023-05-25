using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIÇàµÇ§ç€Ç…ïKóv

public class PlayerMoveh : MonoBehaviour
{
    public Slider slider;
    private float speed = 3.0f;

    void Start()
    {
        slider.value = 3;
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
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "PointDown")
        {
            slider.value--;
        }

        if (other.gameObject.name == "PointUp")
        {
            slider.value++;
        }
    }
}