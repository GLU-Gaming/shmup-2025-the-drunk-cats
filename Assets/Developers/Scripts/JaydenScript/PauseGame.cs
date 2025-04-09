using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject retryMenuUI;
    public GameObject quitMenuUI;

    [SerializeField] private AudioClip pauseSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        if (pauseSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pauseSound);
        }
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeButton()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void RetryButton()
    {
        pauseMenuUI.SetActive(false);
        retryMenuUI.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToPause()
    {
        quitMenuUI.SetActive(false);
        retryMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void QuitButton()
    {
        pauseMenuUI.SetActive(false);
        quitMenuUI.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
