using UnityEngine;
// This script is to move the GameObject propell upwards when the Up Arrow Key is pressed. 
public class MoveBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * 3, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 3, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 3, ForceMode.Impulse);
        }
    }
}
