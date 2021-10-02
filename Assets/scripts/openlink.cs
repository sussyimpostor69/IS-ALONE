using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openlink : MonoBehaviour
{
    public void OpenChannel()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCrWrPthJ_tI8iUP_XcEF6UA");
    }
    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.gg/EwrCNTjTz3");
    }

}
