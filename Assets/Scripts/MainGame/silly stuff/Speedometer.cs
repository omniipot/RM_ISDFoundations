using UnityEngine;
using TMPro;
using NUnit.Framework;

public class Speedometer : MonoBehaviour
{

    
   public PlayerMovement playerMovement;
   public TMP_Text SpeedText;
   public string SpeedString;
   public Transform Needle;
   public float MinAngle;
   public float MaxAngle;
   public float maxSpeed;
   public GameObject Speedlines;
    void Start()
    {
        Speedlines.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        float roundedvalue = Mathf.Round(playerMovement.ActualSpeed * 100f) / 100f;
        SpeedString = roundedvalue.ToString();
        SpeedText.text = SpeedString + " M/S";

        Needle.localEulerAngles = new Vector3(0,0, Mathf.Lerp(MinAngle, MaxAngle, roundedvalue / maxSpeed));

        if (roundedvalue > 14f)
        {
            Speedlines.SetActive(true);
        }
        else
        {
            Speedlines.SetActive(false);
        }
    }
}
