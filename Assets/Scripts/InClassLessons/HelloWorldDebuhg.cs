using UnityEngine;

public class HelloWorldDebuhg : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnDisable()
    {
        Debug.Log("Goodbye world");
    }


    void OnEnable()
    {
        Debug.Log("Hi world");
    }

}
