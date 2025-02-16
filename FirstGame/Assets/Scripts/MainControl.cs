using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;
public class MainControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider backgroundSlider;
    public Slider sfxSlider;
    public Animator cameraAnimator;
    private Character spawn;

    public GameObject karakter;
    public GameObject mainPanel;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject highScorePanel;
    public GameObject gameOverPanel;
    public GameObject pauseButton;
    public Button turkishButton;
    public Button englishButton;
    public Button startButton;
    public TextMeshProUGUI skor;
    public TextMeshProUGUI skorText;
    public int score = 0;
    public int count = 1;
    public static float x = 1f; 
    public static float y = 1f; 

    void Start()
    {
        spawn = GameObject.Find("virus").GetComponent<Character>();
        Time.timeScale = 1f;
        pauseButton.SetActive(false);
        skor.gameObject.SetActive(false);
        skorText.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartCameraAnimation);
        backgroundSlider.onValueChanged.AddListener(SetBackgroundVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        turkishButton.onClick.AddListener(() => SetLanguage("tr"));
        englishButton.onClick.AddListener(() => SetLanguage("en"));
    }
    void StartCameraAnimation()
    {
        GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
        foreach (GameObject trap in traps)
        {
            ObjectMovement trapController = trap.GetComponent<ObjectMovement>();
            trapController.StartGame();
        }
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject floor in floors)
        {
            GroundLooper floorController = floor.GetComponent<GroundLooper>();
            floorController.FloorMovement();
        }
        spawn.SpawnObject();
        pauseButton.SetActive(true);
        skor.gameObject.SetActive(true);
        skorText.gameObject.SetActive(true);
        skor.text = score.ToString();
        mainPanel.SetActive(false);
        cameraAnimator.SetTrigger("start_trg");
    }

    public void SkorArtir()
    {
        score += 10;
        skor.text = score.ToString();
        count++;
        //Debug.Log("COunt: " + count);
        if (count >= 11)
        {
            x = Mathf.Max(0.1f, x - 0.1f);
            y += 0.1f;
            count = 1;
            Debug.Log(x + " - " + y);
        }
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
