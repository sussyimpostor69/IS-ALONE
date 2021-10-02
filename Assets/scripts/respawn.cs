using UnityEngine.SceneManagement;
using UnityEngine;

public class restart : MonoBehaviour
{

    public Transform point;

    public void EndGame1()
    {
        if (gamehasended == false)
        {
            gamehasended = true;
            Debug.Log("game over");
            Invoke("Restart1", restartdelay);
            gamehasended = false;
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EndGame1();
        }

    }
    void Restart1()
    {
        transform.position = point.position;
    }
    bool gamehasended = false;

    public float restartdelay = 1f;
}
