using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverOverlay;
    public TextMeshProUGUI bestWaveText;

    public FPSController fpsController;
    public Cannon cannon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bestWaveText.SetText("Best: " + PlayerPrefs.GetInt("HighestWave"));
    }

    public void RestartGame()
    {
        //Show Game Over Overlay
        gameOverOverlay.SetActive(true);

        //Dissable Mechanics of FPS controller
        fpsController.enabled = false;
        cannon.enabled = false;

        //check current wave and replace best if higher
        if (ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
            bestWaveText.SetText("Best: " + PlayerPrefs.GetInt("HighestWave"));
        }

        //restart scene after x seconds
        StartCoroutine(GameOverCo());
    }

    private IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(3);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
