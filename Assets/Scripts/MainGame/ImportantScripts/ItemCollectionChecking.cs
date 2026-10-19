using UnityEngine;
// this script updates the UI for when you complete a keypad or find a key
public class ItemCollectionChecking : MonoBehaviour
{

    public PlayerDetection playerDetection;

    public GameObject Key1Tick;
    public GameObject Key2Tick;
    public GameObject KeypadColourTick;
    public GameObject KeypadShapeTick;
    public GameObject KeypadMixedTick;
    public AudioClip FoundSFX;
    public AudioSource SFXSource;
    
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKeyDisplay()
    {
        if(playerDetection.hasKey1 == true)
        {
            Key1Tick.SetActive(true);
            playFoundSFX();
        }
        if(playerDetection.hasKey2 == true)
        {
            Key2Tick.SetActive(true);
            playFoundSFX();
        }
    }

    public void UpdateKeypadDisplay(string keypadType)
    {
        if(keypadType == "Colour"  )
        {
            KeypadColourTick.SetActive(true);
            playFoundSFX();
        }

        else if(keypadType == "Shape" )
        {
            KeypadShapeTick.SetActive(true);
            playFoundSFX();
        }

        else if(keypadType == "Mixed"  )
        {
            KeypadMixedTick.SetActive(true);
            playFoundSFX();
        }
    }

    void playFoundSFX()
    {
        SFXSource.PlayOneShot(FoundSFX);
    }
}
