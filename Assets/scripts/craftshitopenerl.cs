using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftshitopenerl : MonoBehaviour
{
    public GameObject firstperson;
    public GameObject Object;

    public void objectshit()
    {
        Object.SetActive(!Object.activeSelf);
    }
    public void objectshit2()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void close()
    {
        Object.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            objectshit();

            if (Object.activeInHierarchy == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (Object.activeInHierarchy == false)
            {
                objectshit2();
            }
        }

    }
}

