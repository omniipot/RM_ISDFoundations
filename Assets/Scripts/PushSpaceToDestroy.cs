using UnityEngine;
// This script is to destroy the GameObject when the Spacebar is pressed.
public class PushSpaceToDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
            
        }
       
    }
}
