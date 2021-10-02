using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invenoryopener : MonoBehaviour
{
    public GameObject firstperson;
    public GameObject InventoryObject;

    public void inventoryshit()
    {
        InventoryObject.SetActive(!InventoryObject.activeSelf);
    }
    public void inventoryshit2()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryshit();
        }
        if (InventoryObject.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //firstperson.SetActive(false);
        }
      
            if (InventoryObject.activeInHierarchy == false)
            {
                inventoryshit2();
            }
        
    }
}

