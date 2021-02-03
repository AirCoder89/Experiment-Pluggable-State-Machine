using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image fill;
        [SerializeField] private Text percentage;
  
        public void SetProgression(float progress)
        {
            fill.fillAmount = progress / 100f;
            if(percentage) percentage.text = progress.ToString("P");
        }

    }
}
