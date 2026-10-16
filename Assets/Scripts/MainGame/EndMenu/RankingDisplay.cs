    
using UnityEngine;
using System.Collections;

public class RankingDisplay : MonoBehaviour
{


    public GameObject RankS;
    public GameObject RankA;
    public GameObject RankB;
    public GameObject RankC;
    public GameObject RankD;

    public GameObject TimeDisplay;

    public GameObject ReplayButton;
    public GameObject MainMenuButton;

    IEnumerator Start()
    {
        // Hide all ranks and UI elements initially
        RankS.SetActive(false);
        RankA.SetActive(false);
        RankB.SetActive(false);
        RankC.SetActive(false);
        RankD.SetActive(false);
            
        TimeDisplay.SetActive(false);

        // Display the correct rank
        switch (EndGame.FinalRank)
        {
            case "S":
                RankS.SetActive(true);
                break;

            case "A":
                RankA.SetActive(true);
                break;

            case "B":
                RankB.SetActive(true);
                break;

            case "C":
                RankC.SetActive(true);
                break;

            case "D":
                RankD.SetActive(true);
                break;

            default:
                Debug.LogWarning("Invalid rank: " + EndGame.FinalRank);
                yield break;
        }

        // Wait 4 seconds
        yield return new WaitForSeconds(4f);

        // Display the time
        TimeDisplay.SetActive(true);
        yield return new WaitForSeconds(2f);
        ReplayButton.SetActive(true);
        MainMenuButton.SetActive(true);
    }
}
