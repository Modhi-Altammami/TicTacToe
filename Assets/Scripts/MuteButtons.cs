using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButtons : MonoBehaviour
{
    
    public void sendAudio()
    {
        AudioManage.instance.AudioControl(gameObject);
    }
}
