using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject menu;

    [HideInInspector]
    public bool playerDied;

    private Animation anim;

    private void Start()
    {
        playerDied = false;
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            PlayerDied();
            return;
        }
    }

    //When player dies
    public void PlayerDied()
    {
        if (!playerDied)
        {
            //Play game over window open animation
            anim.Play("Game-Over-In");
            
            //Disable game menu.
            menu.SetActive(false);

            playerDied = true;
        }
    }
}
