using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /*
     * 
     * Makes button auto-fire.
     * 
     */

    [Header("FireButton Setup Field")]
    public static bool CanShoot;

    private void Start()
    {
        CanShoot = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Start Fire
        CanShoot = true;
        Debug.Log("Firing");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Cancel Fire
        CanShoot = false;
        Debug.Log("Stopped Firing");
    }
}
