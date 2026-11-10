using UnityEngine;
using TMPro;
public class KeyHoldTracker : MonoBehaviour
{
    private float pressStartTime = 0f;
    private bool isHolding = false;
    public MainMenu mainMenu;
    public float resetTimeThreshold = 2f; // Time in seconds to hold the key before triggering the reset
    public TextMeshProUGUI resetText; // Reference to the TextMeshProUGUI component for displaying the reset message

    void Update()
    {
        // When the key is first pressed down
        if (Input.GetKeyDown(KeyCode.R))
        {
            pressStartTime = Time.time;
            isHolding = true;
        }

        // While the key is being held down
        if (isHolding && Input.GetKey(KeyCode.R))
        {
            float holdDuration = Time.time - pressStartTime;
            resetText.text = "Hold R to reset" + "...";
            if (holdDuration >= resetTimeThreshold)
            {
                // Call the reset function here
                mainMenu.playGame();
            }
        }

        // When the key is released
        if (Input.GetKeyUp(KeyCode.R))
        {
            float totalHoldTime = Time.time - pressStartTime;
            isHolding = false;
        }
    }
}
