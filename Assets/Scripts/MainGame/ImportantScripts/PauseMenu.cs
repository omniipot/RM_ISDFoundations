using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public MainMenu mainMenu;
    public GameObject pauseMenuUI; // Reference to the pause menu UI GameObject
    public bool enablePauseMenu = false; // Flag to enable or disable the pause menu functionality
    public GameObject Player; // Reference to the player GameObject
    void Start()
    {
         pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (enablePauseMenu)
            {
                if (Time.timeScale == 1f)
                {
                    pauseMenuUI.SetActive(true);
                    Time.timeScale = 0f; // Pause the game
                    Cursor.visible = true; // Show the cursor when the keypad is active
                    Cursor.lockState = CursorLockMode.None; // Unlock the cursor when the keypad is active
                    Player.GetComponent<PlayerMovement>().enabled = false;
                }
                else
                {
                    pauseMenuUI.SetActive(false);
                    Time.timeScale = 1f; // Resume the game    
                    Cursor.visible = false; // Show the cursor when the keypad is active
                    Cursor.lockState = CursorLockMode.Locked; // Unlock the cursor when the keypad is active
                    Player.GetComponent<PlayerMovement>().enabled = true;
                }
            }
        }
    }
}
