using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     * 
     * It constantly updates the target to be the nearest "Enemy".
     * It locks on to the nearest "Enemy".
     * When we press Shoot button, It instantiates Bullet Prefab.
     * Decides turn speed of the Player.
     * Bullet uses firePoint and fireEndPoint in its own script.
     * 
     */

    [Header("Player Setup Field")]
    private Transform target;
    public string enemyTag = "Enemy";
    public GameObject crashedParticles;
    private bool didItVibrate = false;

    [Header("Player Properties Field")]
    public float turnSpeed = 5f;
    public float fireRate = 0.7f;
    private float nextFire = 0f;

    [Header("For Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform fireEndPoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
            return;
        else
            LockOnTarget();

        if (FireButton.CanShoot && !GameManager.GameIsPaused && !GameManager.GameIsOver)
        {
            Shoot();
        }
        else if (GameManager.GameIsOver)
        {
            if (!didItVibrate)
            {
                PlayerDied();
            }   
        }
    }

    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
        }
    }

    private void PlayerDied()
    {
        crashedParticles.SetActive(true);
        turnSpeed = 0f;

        //If vibration is enabled, vibrate the device
        if (Settings.GetSetting("Vibration"))
        {
            Handheld.Vibrate();
        }
        didItVibrate = true;
    }

    #region Lock & Update Target

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void LockOnTarget()
    {
        Vector2 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //We decreased Z Rotation by 90 to arrange X axis towards forward.
        Quaternion rotation = Quaternion.AngleAxis(rotationZ - 90f, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    #endregion

}
