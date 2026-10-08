using UnityEngine;
// This script will allow the player to destroy an object, by clicking.
public class ClickToDestroy : MonoBehaviour
{

    public GameObject ClickOBJToDestroy; // Reference to the object that will be destroyed

    void OnMouseDown()
    {
        Debug.Log("Object Was Clicked");
        //Debug.LogWarning("Object Was Clicked");
        //Debug.LogError("Object Was Clicked");//this will stop playmode when ran
        Destroy(ClickOBJToDestroy); // Destroy the object when it is clicked
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
