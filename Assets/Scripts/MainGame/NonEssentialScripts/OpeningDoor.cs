using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningDoor : MonoBehaviour
{

    public MainMenu mainMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Running1");
        StartCoroutine(DoorSequence());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoorSequence()
    {
        while (true)
        {
            Debug.Log("Running");
            yield return new WaitForSeconds(3f);
             mainMenu.playGame();

        }
    }
}

            

