using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    /*
     * 
     * Decides which buff to instantiate and what that buff does.
     * Finds "Player" and makes the buff follow "Player".
     * 
     */

    [Header("Buff Setup Field")]
    private Vector3 direction;
    private BuffSpawner buffSpawner;

    [Header("Buff Properties Field")]
    public string buffName;
    public float buffSpeed = 0.2f;
    public float buffAmount;
    private float buffDisappearCountdown = 15f;
    private bool willBuffDisappear = false;

    [Header("Audio Field")]
    public AudioClip getHitAudio;

    private void Start()
    {
        buffSpawner = GameObject.Find("GameManager").GetComponent<BuffSpawner>();
    }

    void Update()
    {
        if (!GameManager.GameIsPaused && !GameManager.GameIsOver)
        {
            if (buffDisappearCountdown <= 0f)
            {
                willBuffDisappear = true;
                Destroy(gameObject);
                buffDisappearCountdown = 15f;
            }
            buffDisappearCountdown -= Time.deltaTime;

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            direction = (player.transform.position - transform.position);
            transform.Translate(direction.normalized * buffSpeed * Time.deltaTime, Space.World);

            if (!willBuffDisappear)
            {
                if (Vector3.Distance(transform.position, player.transform.position) <= 0.6f)
                {
                    if (buffName == "Health")
                    {
                        if (PlayerStats.Lives < 10)
                        {
                            PlayerStats.Lives++;
                        }
                        Destroy(gameObject);
                    }
                    else if (buffName == "FireRate")
                    {
                        if (player.GetComponent<Player>().fireRate > 0.1f)
                        {
                            player.GetComponent<Player>().fireRate -= 0.05f;
                            buffSpawner.ChangeBulletSpeed();
                            Destroy(gameObject);
                        }
                        else
                        {
                            player.GetComponent<Player>().fireRate = 0.1f;
                            buffSpawner.ChangeBulletSpeed();
                            Destroy(gameObject);
                        }
                    }

                    AudioSource.PlayClipAtPoint(getHitAudio, transform.position);
                }
            }
        }
    }
}
