using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// This script will allow the player to interact with a keypad object, when the player is in range, UI will appear on the screen.
// if the code is correct a trigger will be set to true.
public class Keypad : MonoBehaviour
{

    public string keypadCode = "1234"; 
    public bool isCodeCorrect = false; 
    public GameObject Keypads; 
    public GameObject Player;
    public Canvas Canvas; 
    public GameObject canvasObject;
    public Text text; 
    
    public PlayerDetection playerDetection; 
    public bool Completed = false;
    public string KeypadType = "";

    public AudioClip Click;
    public AudioClip Failure;
    public AudioSource SFXSource;

    public ItemCollectionChecking itemCollectionChecking;
    public ReactionController reactionController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
       Keypads.SetActive(false); 
       canvasObject.SetActive(false);
    
       Clear(); // Clear the text at the start due to bug idk how to fix it but this is a temporary solution
    }

    public void Number(int number)
    {
        text.text += number.ToString(); 
    }

    public void Clear()
    {
        text.text = ""; 
    }
    public void SetCode(string newCode)
    {
        keypadCode= newCode;
        isCodeCorrect = false;
        Completed = false;
        Clear();
    }
    public void Enter()
    {      
        if (Completed)
        {
            text.text = "You've been here already! GO FASTER!!";
            Invoke("Exit", 0.2f );
            return;
        }

        if (text.text == keypadCode)
        {
            isCodeCorrect = true; 
            Debug.Log("Code is correct!");
            text.text = "Correct Code!"; 
            Invoke("Clear", 0.5f); 
            Invoke("Exit", 0.5f); 
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked; 
            playerDetection.increasePartsCollected(); 
            Completed = true;
            itemCollectionChecking.UpdateKeypadDisplay(KeypadType);
            
            
        }
        
        else
        {
            isCodeCorrect = false; 
            Debug.Log("Code is incorrect!");
            text.text = "Incorrect Code!"; 
            Invoke("Clear", 0.5f); 
            reactionController.Play("lockin");
            PlayFailure();
        }
    }

    public void Exit()
    {
       Keypads.SetActive(false); // Hide the keypad UI
       canvasObject.SetActive(false);
       Player.GetComponent<PlayerMovement>().enabled = true; 
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Q))
            {
                Invoke("Exit", 0f);
            }
    }
    public void OpenKeypad()
    {
        StartCoroutine(EnableDisableEnable());
        Canvas.ForceUpdateCanvases(); 
        Player.GetComponent<PlayerMovement>().enabled = false; 
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
        
    }

    public void PlayClick()
    {
        SFXSource.PlayOneShot(Click);
    }

    public void PlayFailure()
    {
        SFXSource.PlayOneShot(Failure);
    }
    public IEnumerator EnableDisableEnable()
    {   
        Keypads.SetActive(true);
        canvasObject.SetActive(true);
        yield return new WaitForSeconds(0.0001f); 
        Keypads.SetActive(false);
        canvasObject.SetActive(false);
        yield return new WaitForSeconds(0.0001f); 
        Keypads.SetActive(true);
        canvasObject.SetActive(true);
    }
}
