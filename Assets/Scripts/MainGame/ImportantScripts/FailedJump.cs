using UnityEngine;
// this script is to check if a player in inside a failed jump zone to punish them for failing the job, and sends them back to the entrance
public class FailedJump : MonoBehaviour
{


    public bool playerInZone = false;

    public Transform SpawnPoint;

    public GameObject Player;

    public Timer timer;

    public ReactionController reactionController;
   
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
            reactionController.Play("fall");
        }
    }
}

