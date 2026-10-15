using UnityEngine;
// This script will Activate the keypad by activating the keypadText GameObject when the player is in range and presses the "E" key.
public class ActivateKeypad : MonoBehaviour
{

    public GameObject keypadText;
    public Object KeypadOB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void OpenKeypad()
    {
        keypadText.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenKeypad();
        }
    }
}
