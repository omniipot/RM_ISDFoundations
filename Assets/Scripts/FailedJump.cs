using UnityEngine;

public class FailedJump : MonoBehaviour
{


    public bool playerInZone = false;

    public Transform SpawnPoint;

    public GameObject Player;

    public Timer timer;
   
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
        }

    private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
        {
            playerInZone = false;
            
            
        }
        }
   

    // Update is called once per frame
    void Update()
    {
        if(playerInZone == true)
        {
            timer.currentTime += 15f;
            Player.transform.position = SpawnPoint.transform.position;
        }
    }
}

