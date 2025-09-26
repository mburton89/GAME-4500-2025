using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
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
        int highestWave = PlayerPrefs.GetInt("HighestWave");
        string highestWaveString = "Best: " + highestWave;
        bestWaveText.SetText(highestWaveString);
    }

    public void RestartGame()
    {
        //Show Game Over Overlay
        gameOverOverlay.SetActive(true);

        //Disable FPS mechanics
        fpsController.enabled = false;
        cannon.enabled = false;

        //Check the current wave and see if we have a new high score
        if (ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
        }

        //Restart scene after X seconds
        StartCoroutine(GameOverCo());

    }

    private IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(3);

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }
}
