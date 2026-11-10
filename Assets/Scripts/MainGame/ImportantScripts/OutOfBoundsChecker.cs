using UnityEngine;
using System;
using TMPro;
using UnityEngine.Purchasing;
// this script is very similar to Failed jump, punishing the player when they go inside a select zone and stays there for X amount of time
//giving them a time penalty when they stay inside the zone for too long
public class OutOfBoundsChecker : MonoBehaviour
{

    public float OOBTimeLimit = 4f;

    private float CheaterTime;

    public bool playerInZone = false;

    public Transform SpawnPoint;

    public GameObject Player;

    public Timer timer;
    public GameObject TextHolder;
    public TMP_Text CountdownText;

    public GameObject Evil;


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
            CheaterTime = 0f;
            
        }
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInZone == true)
        {
            CheaterTime += Time.deltaTime;

            TextHolder.SetActive(true);
            float timeLeft = Mathf.Max(0f,OOBTimeLimit - CheaterTime);

            CountdownText.text = Mathf.CeilToInt(timeLeft).ToString();
           

        }
        else
        {
            CheaterTime -= Time.deltaTime * 0.5f;

            CheaterTime = Mathf.Max(CheaterTime, 0f);
            TextHolder.SetActive(false);
        }

        if(CheaterTime >= OOBTimeLimit)
        {
            timer.currentTime += 60f;
            Player.transform.position = SpawnPoint.transform.position;
            CheaterTime = 0f;
            playerInZone = false;
            TextHolder.SetActive(false);
        }
    }
}
