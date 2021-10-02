using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
    public void scenemanage()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void scenemanagers()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void scenemanager()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
