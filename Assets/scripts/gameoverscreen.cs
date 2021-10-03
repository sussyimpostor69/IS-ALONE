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
        SceneManager.LoadSceneAsync("Survival Island");
    }

    public void ExitButton()
    {
        SceneManager.LoadSceneAsync("main menu");
    }
}
