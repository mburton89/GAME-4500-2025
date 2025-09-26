using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject deathOverlay;

    public TextMeshProUGUI bestWavetext;

    public FPSController fpsController;
    public Cannon cannon;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        int highestWave = PlayerPrefs.GetInt("HighestWave");
        string highestWaveString = "Best: " + highestWave;
        bestWavetext.SetText(highestWaveString);
    }

    public void RestartGame()
    {
        // Show death overlay
        deathOverlay.SetActive(true);

        // Disable FPS mechanics
        fpsController.enabled = false;
        cannon.enabled = false;

        //Check wave for new high score
        if(ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
        }

        //Restart scene after x sec.
        StartCoroutine(DeathCo());

    }

    private IEnumerator DeathCo()
    {
        yield return new WaitForSeconds(3);

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }

}
