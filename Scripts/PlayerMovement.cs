using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
     * 
     * Moves Player with Joystick.
     * Can move Player with TouchScreen.
     * 
     */

    [Header("MovePlayer Properties Field")]
    public float playerSpeed = 4.5f;

    [Header("Joystick Field")]
    protected Joystick joystick;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        if (!GameManager.GameIsPaused && !GameManager.GameIsOver)
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(joystick.Horizontal * playerSpeed, joystick.Vertical * playerSpeed);

            //Movement restriction
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.55f), Mathf.Clamp(transform.position.y, -4.8f, 4.9f), transform.position.z);
        }
        else if (GameManager.GameIsOver)
        {
            playerSpeed = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }

        #region Touch Screen Movement

        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x + playerOffsetX, direction.y + playerOffsetY) * playerSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
        */

        #endregion
    }
}
