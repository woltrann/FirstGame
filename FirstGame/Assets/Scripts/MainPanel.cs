using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider backgroundSlider;
    public Slider sfxSlider; 
    public Animator cameraAnimator;     // Kameranın Animator bileşeni
    //public Animator characterAnimator;  // Karakterin Animator bileşeni

    public GameObject mainPanel;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject highScorePanel;
    public GameObject gameOverPanel;
    public GameObject pauseButton;
    public Button turkishButton;
    public Button englishButton;
    public Button startButton;
    public float forwardSpeed = 100f;
   

    void Start()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(false);
        startButton.onClick.AddListener(StartCameraAnimation);
        //characterAnimator.SetFloat("Speed_f",0.1f);
        backgroundSlider.onValueChanged.AddListener(SetBackgroundVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        turkishButton.onClick.AddListener(() => SetLanguage("tr"));
        englishButton.onClick.AddListener(() => SetLanguage("en"));
    }
    void StartCameraAnimation()
    {
        pauseButton.SetActive(true);
        mainPanel.SetActive(false);
        cameraAnimator.SetTrigger("start_trg");
        //characterAnimator.SetFloat("Speed_f", 0.5f);
        Debug.Log("Camera animation started");
    }

    public void PausePanelOpen()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PausePanelClose()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SettingsPanelOpen() => settingsPanel.SetActive(true);
    public void SettingsPanelClose() => settingsPanel.SetActive(false); 
    public void HighScorePanelOpen() => highScorePanel.SetActive(true);
    public void HighScorePanelClose() => highScorePanel.SetActive(false);
    public void GameOverPanelOpen() => gameOverPanel.SetActive(true);
    public void SetBackgroundVolume(float volume) => audioMixer.SetFloat("BackgroundVolume", Mathf.Log10(volume) * 20);
    public void SetSFXVolume(float volume) => audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    public void SetLanguage(string localeCode) => LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(localeCode);
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void ExitGame() => Application.Quit();

    
}
