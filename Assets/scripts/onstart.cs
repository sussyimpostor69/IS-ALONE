using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onstart : MonoBehaviour
{
    
    public bool urmom = false;
    public GameObject yes;
    public GameObject fps;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        fps.SetActive(false);
        map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(urmom == false)
        { 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Locked;
                urmom = true;
                yes.SetActive(false);               
                fps.SetActive(true);
                map.SetActive(true);                
            }
        }
    }
}
