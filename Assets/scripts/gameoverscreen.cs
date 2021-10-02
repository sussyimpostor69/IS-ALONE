using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverscreen : MonoBehaviour
{
    public void Setup(int score)
    {
        gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Survival Island");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("main menu");
    }
}
