using UnityEngine;
using TMPro;
// this script handles all of the interaction of the player between objects, which is differenticated via tags. 


public class PlayerDetection : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public bool hasKey1 = false;
    public bool hasKey2 = false; 

    public ItemCollectionChecking itemCollectionChecking;
    
    public float interactionRange = 3f; 

    public int partsCollected = 0; 

    public ReactionController reactionController;

    
    public TextMeshProUGUI InteractionText;
    
    public OpenObject openObject; 
    public OpenPaper openPaper;
    public void increasePartsCollected()
    {
        partsCollected++;
        Debug.Log("Parts collected: " + partsCollected);
    
    }

   
    void Start()
    {
       

    }

    
       void Update()

    {
        InteractionText.text = ""; 
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, interactionRange))
        
        {
            //KEY 1
            if(hitInfo.collider.CompareTag("Key1"))
            { InteractionText.text = "Press E to pick up Key 1";
              
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hasKey1 = true;
                    Destroy(hitInfo.collider.gameObject);
                    reactionController.Play("Key1");
                   
                    increasePartsCollected(); 
                    itemCollectionChecking.UpdateKeyDisplay();
                }
            }
            //KEY 2
            else if(hitInfo.collider.CompareTag("Key2"))
            { InteractionText.text = "Press E to pick up Key 2"; 
              
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hasKey2 = true;
                    Destroy(hitInfo.collider.gameObject);
                     reactionController.Play("Key2");

                    increasePartsCollected(); 
                    itemCollectionChecking.UpdateKeyDisplay();
                }
            }
            
            else if(hitInfo.collider.CompareTag("Keypad"))
            { InteractionText.text = "Press E to interact with the " + hitInfo.collider.name + " Keypad"; 
              
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
                    OpenObject openObject = hitInfo.collider.GetComponentInParent<OpenObject>();
                    
                    
                    if (openObject != null && openObject.Interactable)
                    {
                        InteractionText.text = "Press E to open";

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            openObject.PlayAnimation();
                        }
                  
                    }
                }

            else if (hitInfo.collider.CompareTag("PaperPaint"))
            {
                InteractionText.text = "Press E to look at the Painting Paper";
                if(Input.GetKeyDown(KeyCode.E))
                {
                    
                    if (openPaper != null)
                    {
                        openPaper.OpenPaperPainting();
                    }
                    else
                    {
                        Debug.LogError("OpenPaper component not found!");
                    }
                }
            }
            else if (hitInfo.collider.CompareTag("PaperBook"))
            {
                 InteractionText.text = "Press E to look at the Book Paper";
                if(Input.GetKeyDown(KeyCode.E))
                {
                   
                    if (openPaper != null)
                    {
                        openPaper.OpenPaperBook();
                    }
                    else
                    {
                        Debug.LogError("OpenPaper component not found!");
                    }
                }

            }
        

        
            else
            {
            }
            Debug.Log("Hit: " + hitInfo.collider.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactionRange, Color.green);
    
        
        }

       
       


    }
}

