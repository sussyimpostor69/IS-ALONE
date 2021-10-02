using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pmenu : MonoBehaviour
{

    public GameObject firstperson;
    public static bool Gameispaused = false;
    public GameObject pausemenuui;
    public GameObject Health;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gameispaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

   









    public void Resume()
    {
        pausemenuui.SetActive(false);
        Time.timeScale = 1f;
        Gameispaused = false;
        Health.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        firstperson.SetActive(true);
        Cursor.visible = false;
    }



    void Pause()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        Gameispaused = true;
        Health.SetActive(false);
        firstperson.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}