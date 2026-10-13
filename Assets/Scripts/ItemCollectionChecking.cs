using UnityEngine;

public class ItemCollectionChecking : MonoBehaviour
{

    public PlayerDetection playerDetection;

    public GameObject Key1Tick;
    public GameObject Key2Tick;
    public GameObject KeypadColourTick;
    public GameObject KeypadShapeTick;
    public GameObject KeypadMixedTick;

    
    

    
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
        }
        if(playerDetection.hasKey2 == true)
        {
            Key2Tick.SetActive(true);
        }
    }

    public void UpdateKeypadDisplay(string keypadType)
    {
        if(keypadType == "Colour"  )
        {
            KeypadColourTick.SetActive(true);
        }

        else if(keypadType == "Shape" )
        {
            KeypadShapeTick.SetActive(true);
        }

        else if(keypadType == "Mixed"  )
        {
            KeypadMixedTick.SetActive(true);
        }
    }

}
