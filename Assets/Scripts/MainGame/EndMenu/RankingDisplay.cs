    
using UnityEngine;
using System.Collections;

public class RankingDisplay : MonoBehaviour
{


    public GameObject RankS;
    public GameObject RankA;
    public GameObject RankB;
    public GameObject RankC;
    public GameObject RankD;

    public AudioSource SFXSource;

    public AudioClip SRank;
    public AudioClip ARank;
    public AudioClip BRank;
    public AudioClip DRank;
    public AudioClip CRank;
    

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
        Cursor.visible = true; // Show the cursor when the keypad is active
        Cursor.lockState = CursorLockMode.None;
        
        // Display the correct rank
        switch (EndGame.FinalRank)
        {
            case "S":
                RankS.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankS();
                break;

            case "A":
                RankA.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankA();
                break;

            case "B":
                RankB.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankB();
                break;

            case "C":
                RankC.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankC();
                break;

            case "D":
                RankD.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankD();
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

    void PlayRankS(){
    SFXSource.PlayOneShot(SRank);
    }

    void PlayRankA(){
    SFXSource.PlayOneShot(ARank);
    }
    void PlayRankB(){
    SFXSource.PlayOneShot(BRank);
    }
    void PlayRankC(){
    SFXSource.PlayOneShot(CRank);
    }
    void PlayRankD(){
    SFXSource.PlayOneShot(DRank);
    }
}
