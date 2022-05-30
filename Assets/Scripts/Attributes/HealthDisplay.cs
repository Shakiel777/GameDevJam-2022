using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;
        public Image fillImage;
        private Slider slider;
        private void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
            slider = GetComponent<Slider>();
        }

        private void Update()
        {
            // GetComponent<Text>().text = String.Format("{0:0}/{1:0}" , health.GetHealthPoints(), health.GetMaxHealthPoints());
            float fillvalue = health.GetHealthPoints()/health.GetMaxHealthPoints();
            slider.value = fillvalue;
        }
    }
}
