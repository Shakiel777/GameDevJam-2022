using UnityEngine;
using System.Collections;

namespace RPG.Menu
{
        public class MusicManager : MonoBehaviour 
    {

        public AudioClip[] levelMusicChangeArray;

        private AudioSource audioSource;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("Don't destroy on load " + name);
        }
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        }


        void OnLevelWasLoaded(int level)
        {
            AudioClip thisLevelMusic = levelMusicChangeArray[level];
            Debug.Log("playing clip: " + thisLevelMusic);
            if (thisLevelMusic) // if there is some music attached
            {
                audioSource.clip = thisLevelMusic;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        public void ChangeVolume(float volume)
        {
            audioSource.volume = volume;
        }
    }
}
