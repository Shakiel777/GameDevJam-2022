using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class EventTrigger : MonoBehaviour
    {
        [SerializeField] GameObject objectToActivate = null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                objectToActivate.SetActive (true);
            }
        }
    }
}
