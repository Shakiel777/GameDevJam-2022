using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Menu
{
    public class LevelManager : MonoBehaviour 
    {

        public float autoLoadNextLevelAfter;

        private void Start()
        {
            if (autoLoadNextLevelAfter <= 0)
            {
                Debug.Log("Level auto load disabled, use a positive number in seconds");
            }
            else
            {
                Invoke("LoadNextLevel", autoLoadNextLevelAfter);
            }
        }

        public void LoadLevel(string name)
        {
            Debug.Log ("Level load requested for: "+name);
            SceneManager.LoadScene(name);
        }
        public void QuitLevel()
        {
            Debug.Log ("Quit game request received");
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            print("Load next level request");

        }
    }
}
