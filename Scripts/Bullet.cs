using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*
     * 
     * Shoots the bullet with Coroutine.
     * If bullet hits an enemy, It destroys the enemy.
     * 
     */

    [Header("Bullet Setup Field")]
    private Player player;
    public Collider2D bulletCollider;
    public Collider2D enemyCollider;
    private bool isCollided = false;
    private GameObject enemy;

    [Header("Bullet Properties Field")]
    public float bulletSpeed;
    public GameObject impactEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (!GameManager.GameIsPaused && !GameManager.GameIsOver)
        {
            if (isCollided)
            {
                HitTarget();
            }

            StartCoroutine(ShootTheBullet());
        }   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isCollided = true;
            enemy = collision.gameObject;
        }
    }

    #region Shooting The Bullet

    public IEnumerator ShootTheBullet()
    {
        yield return StartCoroutine(MoveTheBullet(transform, player.firePoint.position, player.fireEndPoint.position, bulletSpeed));
        Destroy(gameObject);
    }

    IEnumerator MoveTheBullet(Transform thisTransform, Vector3 startPos, Vector3 endPos, float speed)
    {
        var i = 0.0f;
        while ((i < 1.0f) && (!isCollided))
        {
            i += Time.deltaTime * speed;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

    #endregion

    private void HitTarget()
    {
        //Effect
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 1f);

        PlayerStats.EnemiesKilled++;
        Destroy(enemy);
        Destroy(gameObject);
    }
}
