using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private AnimationController animationController;
    private bool clicked;

    private void Awake()
    {
        GameManager.GameIsPaused = false;
    }

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
        clicked = false;
    }

    private void Update()
    {
        if (PauseButton.IsPauseClicked)
        {
            //This way it will be called just once
            if (!clicked)
            {
                if (GameManager.GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            clicked = true;
        }
    }

    public void Resume()
    {
        //pauseMenu.SetActive(false);

        //Resume player controller, enemy movement, buff movement, buff and enemy spawns.

        //Close pause window.
        animationController.CloseWindow();
        GameManager.GameIsPaused = false;
        clicked = false;
    }

    public void Pause()
    {
        //pauseMenu.SetActive(true);

        //Pause player controller, enemy movement, buff movement, buff and enemy spawns.
        

        //Open pause window.
        animationController.OpenWindow();
        GameManager.GameIsPaused = true;
    }
}
