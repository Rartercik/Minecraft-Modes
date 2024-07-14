using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Game.MenuComponetns
{
    public class LanguageChooser : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _languageShower;

        public void OpenPanel()
        {
            _panel.SetActive(true);
            _languageShower.SetActive(false);
        }

        public void ChooseLanguage(int localeID)
        {
            _panel.SetActive(false);
            _languageShower.SetActive(true);
            StartCoroutine(SetLanguage(localeID));
        }

        private IEnumerator SetLanguage(int localeID)
        {
            yield return LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        }
    }
}
