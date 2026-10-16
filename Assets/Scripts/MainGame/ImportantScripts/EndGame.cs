using UnityEngine;
using UnityEngine.SceneManagement;
// this script ends the game when you enter a collider, this stops the timer, calculates your rank and prevents further movement.
public class EndGame : MonoBehaviour
{
    public Timer timer;
    private bool hasFinished = false;
    public RankingSystem rankingSystem;

    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFinished)
        {
            hasFinished = true;
            timer.StopTimer();
            string rank = rankingSystem.CalculateRank(timer.currentTime);
            playerMovement.canMove = false;

            Debug.LogWarning("FinalTime: "  + timer.currentTime);
            Debug.LogWarning("Player Rank: " + rank);

            SceneManager.LoadSceneAsync(2);

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

}
