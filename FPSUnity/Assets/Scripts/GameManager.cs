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
        int HighestWave = PlayerPrefs.GetInt("HighestWave");
        string highestWaveString = "Best " + HighestWave;
        bestWaveText.SetText(highestWaveString);
    }


    public void RestartGame()
    {
        gameOverOverlay.SetActive(true);

        fpsController.enabled = false;
        cannon.enabled = false;

        if (ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
        }

        StartCoroutine(GameOverCO());
    }


    private IEnumerator GameOverCO()
    {
        yield return new WaitForSeconds(3);
        int currentscene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentscene);
    }



}
