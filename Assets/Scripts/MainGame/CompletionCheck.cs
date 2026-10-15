using UnityEngine;
// this script just checks that all conditions for leaving has been met
public class CompletionCheck : MonoBehaviour

{
    public KeyDetectionTrigger keyDetectionTrigger;
    public PlayerDetection playerDetection;
    public bool DoorOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyDetectionTrigger.Key1Inserted && keyDetectionTrigger.Key2Inserted && playerDetection.partsCollected == 5)
        {
            DoorOpen = true;
        }
    }


}
