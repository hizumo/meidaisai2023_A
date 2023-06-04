using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Result : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score; //TextMeshPro‚Ì•Ï”éŒ¾
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = string.Format("{0} ", PlayerController1.score);
    }
}
