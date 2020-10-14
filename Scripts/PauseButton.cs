using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool IsPauseClicked;

  

    void Start()
    {
        IsPauseClicked = false;        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Pause
        IsPauseClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Resume
        IsPauseClicked = false;
    }
}
