using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject gameOverOverlay;

    public Button restartButton;

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
        string highestwaveString = "Best: " + highestWave;
        bestWaveText.SetText(highestwaveString);
    }

    public void RestartGame()
    {
        //show game over overlay
        gameOverOverlay.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //disable FPS mechanics
        fpsController.enabled = false;
        cannon.enabled = false;
        
        //check current wave and see if there's a new hi score
        if (ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
        }

        //restart scene on button click
        restartButton.onClick.AddListener(ResetScene);
    }


    public void ResetScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    //private IEnumerator GameOverCo()
    //{
    //    yield return new WaitForSeconds(3);

    //    int currentScene = SceneManager.GetActiveScene().buildIndex;

    //    SceneManager.LoadScene(currentScene);
    //}

}
