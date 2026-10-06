using UnityEngine;
// This script is to move the GameObject Upwards when the Up Arrow Key is pressed. 
public class MoveBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       int speed = 5;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
