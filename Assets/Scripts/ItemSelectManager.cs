//Not Using
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSelectManager : MonoBehaviour
{
    public GameObject mainCamera;

    public Ray ray;
    public Ray rayItem;
    public RaycastHit hit;

    public GameObject rocket;
    public GameObject backPack;
    public GameObject itemSprite;
    public GameObject selectedItem;
    private int itemQuantity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedItem = null;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                Vector3 bpPosition = backPack.transform.position;
                var parent = this.transform;
                selectedItem = hit.collider.gameObject;
                Debug.Log("You chose an itemÅI");
                Instantiate(itemSprite, bpPosition, Quaternion.identity, parent);
            }
        }
    }
}
