using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController1;

public class InventoryScript : MonoBehaviour
{
    //�C���x���g���p�l���̐ݒ�
    [SerializeField] GameObject panelI;
    [SerializeField] GameObject panelG;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void InventoryClick()
    {
        panelG.SetActive(false);
        panelI.SetActive(true);
        
    }
    public void GameClick()
    {
        panelG.SetActive(true);
        panelI.SetActive(false);
        
    }
}
