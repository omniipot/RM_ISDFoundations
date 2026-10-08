using UnityEngine;
using UnityEngine.UI;

// This script will allow the player to interact with a keypad object, when the player is in range, UI will appear on the screen.
// if the code is correct a trigger will be set to true.
public class Keypad : MonoBehaviour
{

    public string keypadCode = "1234"; // The correct code for the keypad
    public bool isCodeCorrect = false; // Whether the code entered is correct
    public GameObject Keypads; // Reference to the keypad UI
    public GameObject Player;
    public Text text; // Reference to the Text component for displaying messages
    
    public PlayerDetection playerDetection; // Reference to the PlayerDetection script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Keypads.SetActive(false); // Hide the keypad UI at the start 
       Clear(); // Clear the text at the start due to bug idk how to fix it but this is a temporary solution
    }

    public void Number(int number)
    {
        text.text += number.ToString(); // Append the number to the text
    }

    public void Clear()
    {
        text.text = ""; // Clear the text
    }

    public void Enter()
    {
        if (text.text == keypadCode)
        {
            isCodeCorrect = true; // Set the trigger to true if the code is correct
            Debug.Log("Code is correct!");
            text.text = "Correct Code!"; // Display a message for correct code
            Invoke("Clear", 2f); // Clear the text after 2 seconds
            Invoke("Exit", 2f); // Close the keypad after 2 seconds
            Cursor.visible = false; // Hide the cursor when the keypad is closed
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor when the keypad is closed
            playerDetection.increasePartsCollected(); // Call the increasePartsCollected method to increment the partsCollected variable
            
        }
        else
        {
            isCodeCorrect = false; // Set the trigger to false if the code is incorrect
            Debug.Log("Code is incorrect!");
            text.text = "Incorrect Code!"; // Display a message for incorrect code
            Invoke("Clear", 2f); // Clear the text after 2 seconds
        }
    }

    public void Exit()
    {
       Keypads.SetActive(false); // Hide the keypad UI
       Player.GetComponent<PlayerMovement>().enabled = true; // Enable player movement
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OpenKeypad()
    {
        Keypads.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false; // Disable player movement when the keypad is active
        Cursor.visible = true; // Show the cursor when the keypad is active
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor when the keypad is active
    }
}
