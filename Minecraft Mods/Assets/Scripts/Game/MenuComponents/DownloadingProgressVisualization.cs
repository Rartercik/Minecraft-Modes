using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.MenuComponents
{
    public class DownloadingProgressVisualization : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private TextMeshProUGUI _percents;

        public void UpdateVisualization(float progress)
        {
            progress = Mathf.Clamp01(progress);
            var percents = (int)(progress * 100f);

            _bar.fillAmount = progress;
            _percents.text = percents.ToString() + '%';
        }
    }
}