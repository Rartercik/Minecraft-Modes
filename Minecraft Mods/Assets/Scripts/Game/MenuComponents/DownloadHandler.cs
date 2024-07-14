using UnityEngine;

namespace Game.MenuComponents
{
    public class DownloadHandler : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private DownloadingProgressVisualization _visualization;
        [SerializeField] private AnimationCurve _progressCurve;
        [SerializeField] private float _downloadTime;

        private Canvas _modeCnavas;
        private float _progress;
        private bool _isDownloading;

        private void Update()
        {
            if (_isDownloading == false) return;

            _progress += Time.deltaTime / _downloadTime;
            _visualization.UpdateVisualization(_progressCurve.Evaluate(_progress));
        }

        public void StartDownloading(Canvas modeCanvas)
        {
            _modeCnavas = modeCanvas;
            SetCanvases(true);
            _isDownloading = true;
            _progress = 0f;
        }

        public void Interrupt()
        {
            SetCanvases(false);
            _isDownloading = false;
            _progress = 0f;
        }

        public void Retry()
        {
            _progress = 0f;
        }

        private void SetCanvases(bool isDownloading)
        {
            _canvas.enabled = isDownloading;
            _modeCnavas.enabled = !isDownloading;
        }
    }
}
