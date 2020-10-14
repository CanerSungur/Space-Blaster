using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    /*
    * 
    * Decide which enemy to spawn.
    * Spawns enemies and buffs according to countdown.
    * Decides the countdown between enemy spawns.
    * When scene loads, it holds the game 3 seconds and then makes it start. 
    * Decrease timeDelay by countdown.
    * 
    */

    [Header("EnemySpawner Setup Field")]
    public GameObject[] enemyPrefabs;
    public Enemy enemy;
    private Transform spawnPoint;

    [Header("EnemySpawner Properties Field")]
    private float timeDelay = 1f;
    private float timeDelayCountdown;
    private float decreaseTime = 0.02f;
    public float countdown = 20f;
    private float nextEnemyBuff = 20f;

    [Header("UI Field")]
    private bool isGameStarted = false;
    public GameObject gameStartPanel;
    public TextMeshProUGUI gameStartText;
    private float uiCountdown = 3;

    private void Start()
    {
        timeDelayCountdown = timeDelay;
        enemy.enemySpeed = 0.7f;
        gameStartPanel.SetActive(true);
    }

    void Update()
    {
        //Countdown at the begining of the game.
        if (!isGameStarted)
        {
            if (uiCountdown <= 0f)
            {
                gameStartPanel.SetActive(false);
                isGameStarted = true;
            }
            
            gameStartText.text = string.Format(("{0:0}"), uiCountdown);
            uiCountdown -= Time.deltaTime;
        }
        else
        {
            if (!GameManager.GameIsPaused && !GameManager.GameIsOver)
            {
                //Spawning enemies by countdown
                if (timeDelayCountdown <= 0f)
                {
                    //Spawn Enemies
                    spawnPoint = SpawnPoints.spawnPoints[Random.Range(0, 18)];
                    Instantiate(enemyPrefabs[Random.Range(0, 3)], spawnPoint.position, spawnPoint.rotation);

                    timeDelayCountdown = timeDelay;
                    return;
                }

                timeDelayCountdown -= Time.deltaTime;
                timeDelayCountdown = Mathf.Clamp(timeDelayCountdown, 0f, Mathf.Infinity);

                //gameStartText.text = string.Format(("{0:0}"), countdownUI);
                //uiCountdown -= Time.deltaTime;

                #region Make Enemies Spawn Faster & Run Faster

                if (countdown <= 0f)
                {
                    if (timeDelay <= 0.5f)
                    {
                        timeDelay = 0.5f;
                    }
                    else
                    {
                        timeDelay -= decreaseTime;
                    }

                    if (enemy.enemySpeed >= 1.2f)
                    {
                        enemy.enemySpeed = 1.2f;
                    }
                    else
                    {
                        enemy.enemySpeed += 0.02f;
                    }

                    countdown = nextEnemyBuff;
                    return;
                }

                countdown -= Time.deltaTime;
                countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

                #endregion
            }
        }
    }
}
