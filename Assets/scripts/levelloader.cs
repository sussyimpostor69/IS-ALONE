using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelloader : MonoBehaviour
{
    public GameObject loadingscreen;

    public Slider Slider;
    public Text progresstext;

    public void loadlevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation oparation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingscreen.SetActive(true);

        while (!oparation.isDone)
        {
            float progress = Mathf.Clamp01(oparation.progress / .9f);
            Slider.value = progress;
            progresstext.text = progress * 100f + "%";

            yield return null;
        }
    }

}
