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

    public FPSController fPSController;
    public Cannon cannon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int highestWave = PlayerPrefs.GetInt("Highest Wave");
        string highestWaveString = "Best: " + highestWave;
        bestWaveText.SetText(highestWaveString);
    }

    public void RestartGame()
    {
        //show GameOverOverlay
        gameOverOverlay.SetActive(true);

        //disable FPS mechanics
        fPSController.enabled = false;
        cannon.enabled = false;

        //Check the current wave and see if we have a new high score
        if (ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("Highest Wave"))
        {
            PlayerPrefs.SetInt("Highest Wave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
        }


        //restart scene after X seconds
        StartCoroutine(GameOverCo());
    }

    private IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(3);

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }

}
