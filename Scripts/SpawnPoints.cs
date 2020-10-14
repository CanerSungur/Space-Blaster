using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    /*
     * 
     * It makes an array of all empty objects that were created as Spawn Points.
     * We used this array to spawn enemies from random places.
     * 
     */
    [Header("SpawnPoints Setup Field")]
    public static Transform[] spawnPoints;

    void Awake()
    {
        spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }
}
