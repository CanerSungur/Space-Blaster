using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    /*
     * 
     * It holds all information of the Player.
     * It holds "High Score" using PlayerPrefs.
     * It fills the Health Bar on screen and calculates Score.
     * It resets "High Score".
     * 
     */

    [Header("Player Static Properties Field")]
    public static float Lives;
    public static int EnemiesKilled;
    public static float Score;
    public GameObject highScoreMessage;

    [Header("UI Field")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("Other Field")]
    private float startLives = 10;

    void Start()
    {
        Lives = startLives;
        EnemiesKilled = 0;
        highScoreMessage.SetActive(false);
        PlayerPrefs.GetFloat("HighScore", 0);
        Debug.Log("High Score: " + PlayerPrefs.GetFloat("HighScore", 0));
    }

    void Update()
    {
        Score = EnemiesKilled * 4;

        scoreText.text = Score.ToString();
        healthText.text = Lives.ToString();

        if (Score > PlayerPrefs.GetFloat("HighScore"))
        {
            highScoreMessage.SetActive(true);
            PlayerPrefs.SetFloat("HighScore", Score);
            highScoreText.text = "TOP: " + Score.ToString();
        }
        else
        {
            highScoreText.text = "TOP: " + PlayerPrefs.GetFloat("HighScore").ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
