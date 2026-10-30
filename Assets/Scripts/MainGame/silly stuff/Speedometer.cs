using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{

    
   public PlayerMovement playerMovement;
   public TMP_Text SpeedText;
   public string SpeedString;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float roundedvalue = Mathf.Round(playerMovement.ActualSpeed * 100f) / 100f;
        SpeedString = roundedvalue.ToString();
        SpeedText.text = SpeedString + " KM/H";
    }
}
