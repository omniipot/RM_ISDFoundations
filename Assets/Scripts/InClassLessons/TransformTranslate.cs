using UnityEngine;

public class TransformTranslate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
        }
    }
}
