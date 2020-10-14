using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    /*
     * 
     * Spawns random buff at the end of every Countdown.
     * Applies the effects of the buff.
     * Decides default values of efected properties.
     * 
     */

    [Header("BuffSpawner Setup Field")]
    public List<GameObject> buffPrefabList;
    private Transform spawnPoint;
    public Bullet bullet;
    public GameObject player;

    [Header("BuffSpawner Properties Field")]
    public float countdown = 20f;
    private float nextBuffSpawn = 20f;

    private void Start()
    {
        bullet.bulletSpeed = 0.5f;
    }

    private void Update()
    {
        if (!GameManager.GameIsPaused && !GameManager.GameIsOver)
        {
            if (countdown <= 0)
            {
                SpawnBuff();
                countdown = nextBuffSpawn;
                return;
            }

            countdown -= Time.deltaTime;
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        }
    }

    private void SpawnBuff()
    {
        spawnPoint = SpawnPoints.spawnPoints[Random.Range(0, 18)];
        Instantiate(buffPrefabList[Random.Range(0, 2)], spawnPoint.position, spawnPoint.rotation);
    }

    public void ChangeBulletSpeed()
    {
        if (bullet.bulletSpeed < 1.34f)
            bullet.bulletSpeed += 0.07f;
        else
            bullet.bulletSpeed = 1.34f;
    }
}
