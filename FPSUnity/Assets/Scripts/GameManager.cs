using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject gameOverOverlay;
    public TextMeshProUGUI bestWaveText;

    public FPSController fpsController;
    public Cannon cannon;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        int highestWave = PlayerPrefs.GetInt("HighestWave");
        string highestWaveString = "Best Wave: " + highestWave;
        bestWaveText.SetText(highestWaveString);
    }

    public void RestartGame()
    {
        gameOverOverlay.SetActive(true);

        //disable FPS mechanics
        fpsController.enabled = false;
        cannon.enabled = false;

        //Check the current wave for high score
        if(ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
        }

        //Restart scene after x seconds
        StartCoroutine(GameOverCo());
    }

    private IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(3);

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }
}
