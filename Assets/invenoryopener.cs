using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invenoryopener : MonoBehaviour
{
    public GameObject firstperson;
    public GameObject InventoryObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryObject.SetActive(!InventoryObject.activeSelf);
        }
        if (InventoryObject.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //firstperson.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InventoryObject.activeInHierarchy == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}

