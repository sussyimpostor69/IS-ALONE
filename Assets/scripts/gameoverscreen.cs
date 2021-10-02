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
        SceneManager.LoadScene("Scene 3");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("menu");
    }
}
