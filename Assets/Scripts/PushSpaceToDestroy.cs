using UnityEngine;
// This script is to destroy the GameObject when the Spacebar is pressed.
public class PushSpaceToDestroy : MonoBehaviour
{ 
    public GameObject objectToDestroy; // Reference to the GameObject to be destroyed
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Destroy(gameObject); // This will destroy the GameObject that this script is attached to.
            //Destroy(this); //This will destroy the script component attached to the GameObject, but not the GameObject itself.
            //Destroy(this.gameObject); // This will destroy the GameObject that this script is attached to.
            Destroy(objectToDestroy); // This will destroy the specified GameObject.
        }   
       
    }
}
