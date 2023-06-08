using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController1;

public class InventoryScript : MonoBehaviour
{
    //インベントリパネルの設定
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
