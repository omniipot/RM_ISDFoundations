using UnityEngine;
using UnityEngine.UIElements;

public class TransformTranslate : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotateSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(0,0,1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(0,0,-1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(1,0,0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(-1,0,0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0,1,0);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.Translate(0,-1,0);
        }*/
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * movementSpeed* Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(transform.up * rotateSpeed* Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-transform.up * rotateSpeed * Time.deltaTime);
        }
    }
}
