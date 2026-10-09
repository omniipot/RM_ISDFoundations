using UnityEngine;
using TMPro;
// This script will set up a raycast that can detect objects in front of the player. 
// When the player is in range of an object, it will display a message that the player is in range.
// Additionally, the player will be able to pick up the object by pressing the "E" key; which will set a variable to true.



public class PlayerDetection : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public bool hasKey1 = false;
    public bool hasKey2 = false; 
    
    public float interactionRange = 3f; // The range at which the player can interact with objects

    public int partsCollected = 0; // Variable to track the number of parts collected

    public TextMeshProUGUI partsCollectedText; // Reference to the TextMeshProUGUI component for displaying parts collected
    public TextMeshProUGUI InteractionText; // Reference to the TextMeshProUGUI component for displaying interaction messages
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public OpenObject openObject; // Reference to the OpenObject Script
    public void increasePartsCollected()
    {
        partsCollected++;
        Debug.Log("Parts collected: " + partsCollected);
        partsCollectedText.text = partsCollected.ToString(); // Update the UI text to display the number of parts collected
    }

   
    void Start()
    {
       

    }

    // Update is called once per frame
       void Update()

    {
        InteractionText.text = ""; // Clear the interaction text at the start of each frame
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, interactionRange))
        
        {
            //KEY 1
            if(hitInfo.collider.CompareTag("Key1"))
            { InteractionText.text = "Press E to pick up Key 1"; // Display interaction message
                Debug.Log("You are in range of Key 1");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hasKey1 = true;
                    Destroy(hitInfo.collider.gameObject);
                    Debug.Log("You have picked up Key 1");
                    increasePartsCollected(); // Call the increasePartsCollected method to increment the partsCollected variable
                }
            }
            //KEY 2
            else if(hitInfo.collider.CompareTag("Key2"))
            { InteractionText.text = "Press E to pick up Key 2"; // Display interaction message
                Debug.Log("You are in range of Key 2");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hasKey2 = true;
                    Destroy(hitInfo.collider.gameObject);
                    Debug.Log("You have picked up Key 2");
                    increasePartsCollected(); // Call the increasePartsCollected method to increment the partsCollected variable
                }
            }
            
            else if(hitInfo.collider.CompareTag("Keypad"))
            { InteractionText.text = "Press E to interact with the Keypad"; // Display interaction message
                Debug.Log("You are in range of the Keypad");
                if(Input.GetKeyDown(KeyCode.E))
                {
                   Keypad keypad = hitInfo.collider.GetComponent<Keypad>();
                   if(keypad != null)
                   {
                       keypad.OpenKeypad();
                   }
                }

            }
            else if (hitInfo.collider.CompareTag("OpenableObject"))
                {
                    InteractionText.text = "Press E to open";
                    Debug.Log("You are in range of the object");
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.LogWarning("Button Input Accepted");
                        OpenObject openObject = hitInfo.collider.GetComponent<OpenObject>();

                        if (openObject != null)
                        {
                            openObject.PlayAnimation();
                        }
                        else
                    {
                        Debug.LogError("OpenObjectScriptNotFound");
                    }
                    }
                }
            
        

        
            else
            {
                Debug.Log("You are not in range of any key");
            }
            Debug.Log("Hit: " + hitInfo.collider.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactionRange, Color.green);
    
        
        }

       
       


    }
}

