using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using TMPro.EditorUtilities;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverOverlay;

    public TextMeshProUGUI bestWaveText;

    public FPSController fpsController;

    public Cannon cannon;

    [SerializeField] private TextMeshProUGUI AmmoCountText;

    private int AmmoCount = 10;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        int highestWave = PlayerPrefs.GetInt("HighestWave");
        string highestWaveString = "Best: " + highestWave;
        bestWaveText.SetText(highestWaveString);
    }

    public void RestartGame()
    {
        //Enable Game Over Overlay
        gameOverOverlay.SetActive(true);

        //Disable FPS/cannon mechanics
        fpsController.enabled = false;
        cannon.enabled = false;
        //Check current wave to check for new high score
        if (ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
            PlayerPrefs.Save();
        }
        //Restart Scene after X seconds
        StartCoroutine(GameOverCo());
    }

    private IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(3);

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }

    public void UpdateAmmoCountUI(int AmmoCount)
    {
        AmmoCountText.text = "Ammo: " + AmmoCount;
    }

    public void ShootInput()
    {
        if (AmmoCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AmmoCount--;
                UpdateAmmoCountUI(AmmoCount);
            }
        }
    }

}
