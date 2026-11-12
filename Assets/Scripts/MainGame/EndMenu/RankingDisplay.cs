    
using UnityEngine;
using System.Collections;
using TMPro;

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

    public AudioClip RankCDSong;
    public AudioClip RankABSong;
    public AudioClip RankSSong;
    

    public TMP_Text TimeDisplay;

    public GameObject ReplayButton;
    public GameObject MainMenuButton;

    IEnumerator Start()
    {
       
        RankS.SetActive(false);
        RankA.SetActive(false);
        RankB.SetActive(false);
        RankC.SetActive(false);
        RankD.SetActive(false);
       
            
        
        Cursor.visible = true; // Show the cursor when the keypad is active
        Cursor.lockState = CursorLockMode.None;
        TimeDisplay.text = "Time: " + EndGame.FinalTime.ToString("F2") + " seconds";
        
        switch (EndGame.FinalRank) // check the result, i used a switch because i felt it was easier to maintain if i wanted to add more ranks
        {
            case "S":
                RankS.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankSong(RankSSong);
                PlayRankS();
                break;

            case "A":
                RankA.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankSong(RankABSong);
                PlayRankA();
                break;

            case "B":
                RankB.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankSong(RankABSong);
                PlayRankB();
                break;

            case "C":
                RankC.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankSong(RankCDSong);
                PlayRankC();
                break;

            case "D":
                RankD.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                PlayRankSong(RankCDSong);
                PlayRankD();
                break;

            default:
                Debug.LogWarning("Invalid rank: " + EndGame.FinalRank);
                yield break;
        }

        
    }

    void PlayRankSong(AudioClip song)
    {
        if (SFXSource == null || song == null)
            return;

        SFXSource.clip = song;
        SFXSource.Play();
    }


    // sound effects
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
