using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Modhi.ticTacToe
{
    public class MuteButtons : MonoBehaviour
    {

        public void sendAudio()
        {
            AudioManage.instance.AudioControl(gameObject);
        }
    }

}
