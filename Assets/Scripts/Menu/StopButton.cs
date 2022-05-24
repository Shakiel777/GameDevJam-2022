using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RPG.Menu
{
    public class StopButton : MonoBehaviour 
    {

        public LevelManager levelManager;

        private void OnMouseDown()
        {
            levelManager.LoadLevel("01a_Start");
        }
    }
}
