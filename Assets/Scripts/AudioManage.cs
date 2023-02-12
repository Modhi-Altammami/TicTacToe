using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Modhi.ticTacToe
{
    public class AudioManage : MonoBehaviour
    {
        public static AudioManage instance;
        private bool isMute;
        private AudioSource AudioClip;
        [SerializeField] private Sprite mute;
        [SerializeField] private Sprite unmute;

        void Awake()
        {
            if (instance == null) // if instance is not initilized then instance is equal to class
                instance = this;
            else
            {
                Destroy(gameObject);
            }

        }

        // Update is called once per frame
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            isMute = false;
            AudioClip = GetComponent<AudioSource>();
        }


        public void AudioControl(GameObject btn)
        {
            if (isMute)
            {
                AudioClip.Play();
                btn.GetComponent<Image>().sprite = unmute;


            }
            else
            {
                AudioClip.Pause();
                btn.GetComponent<Image>().sprite = mute;


            }

            isMute = !isMute;
        }
    }
}