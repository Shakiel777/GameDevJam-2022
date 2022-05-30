using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RPG.Saving;
using TMPro;
using System.IO;

namespace RPG.SceneManagement
{
    public class MenuController : MonoBehaviour
    {
        const string saveFile = "save";

        [Header("Volume Settings")]
        [SerializeField] private TMP_Text volumeTextValue = null;
        [SerializeField] private Slider volumeSlider = null;
        [SerializeField] private float defaultVolume = 1.0f;
        

        [SerializeField] private GameObject confirmationPrompt = null;

        [Header("Levels to Load")]
        public string _newGameLevel;
        private string levelToLoad;

        [SerializeField] private GameObject noSavedGameDialog = null;

        public void NewGameDialogYes()
        {
            
            SceneManager.LoadScene(_newGameLevel);
        }

        public void LoadGameDialogYes()
        {
            string path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path))
            //if(PlayerPrefs.HasKey("save"))
            {
                GetComponent<SavingSystem>().Load(saveFile);
                // levelToLoad = PlayerPrefs.GetString("save");
                // SceneManager.LoadScene(levelToLoad);
            }  
            else
            {
                noSavedGameDialog.SetActive(true);
            }
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        public void SetVolume(float volume)
        {
            AudioListener.volume = volume;
            volumeTextValue.text = volume.ToString("0.0");
        }

        public void VolumeApply()
        {
            PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
            //Show Prompt
            StartCoroutine(ConfirmationBox());
        }

        public void ResetButton(string MenuType)
        {
            if (MenuType == "Audio")
            {
                AudioListener.volume = defaultVolume;
                volumeSlider.value = defaultVolume;
                volumeTextValue.text = defaultVolume.ToString("0.0");
                VolumeApply();
            }
        }

        public IEnumerator ConfirmationBox()
        {
            confirmationPrompt.SetActive(true);
            yield return new WaitForSeconds(2);
            confirmationPrompt.SetActive(false);
        }

        private string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }
    }
}
