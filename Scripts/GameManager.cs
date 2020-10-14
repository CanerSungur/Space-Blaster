using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * 
     * It opens "Game Over" UI, "Menu" scene and reloads the game.
     * It decides if the game is over or not.
     * 
     */

    [Header("Game Setup Field")]
    public static bool GameIsOver;
    public static bool GameIsPaused;

    //[Header("UI Field")]
    //public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
        GameIsPaused = false;
    }

    void Update()
    {
        if (!GameIsOver)
        {
            if (PlayerStats.Lives <= 0)
            {
                GameIsOver = true;
                Debug.Log("GAME OVER!!");
            }
        }
    }
}
