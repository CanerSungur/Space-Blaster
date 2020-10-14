using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
     * 
     * Finds "Player" on scene and goes towards it.
     * If it reaches the "Player", Player takes damage.
     * If Enemy takes damage, it destroys.
     * Increase Enemy speed by countdown.
     * 
     */

    [Header("Enemy Setup Field")]
    private Vector3 direction;

    [Header("Enemy Properties Field")]
    public float enemySpeed;

    [Header("Audio Field")]
    public AudioClip getHitAudio;

    void Update()
    {
        if (!GameManager.GameIsPaused && !GameManager.GameIsOver)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            direction = (player.transform.position - transform.position);
            transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, player.transform.position) <= 0.5f)
            {
                PlayerStats.Lives--;
                AudioSource.PlayClipAtPoint(getHitAudio, transform.position);

                //If vibration is enabled, vibrate the device
                if (Settings.GetSetting("Vibration"))
                {
                    Handheld.Vibrate();
                }
                Destroy(gameObject);
            }
        }

        

        /*
        #region Making Enemies Faster

        if (countdown <= 0)
        {
            if (enemySpeed >= 1.2f)
            {
                enemySpeed = 1.2f;
            }
            else
            {
                enemySpeed += 0.02f;
            }

            countdown = nextEnemyBuff;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        #endregion
        */

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
