using UnityEngine;
using System;
using Unity.PlasticSCM.Editor.WebApi;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.Purchasing;

public class OutOfBoundsChecker : MonoBehaviour
{

    public float OOBTimeLimit = 4f;

    private float currentTime;

    public bool playerInZone = false;

    public Transform SpawnPoint;

    public GameObject Player;

    public Timer timer;
    public GameObject TextHolder;
    public TMP_Text CountdownText;

    public Image Evil;


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
            currentTime = 0f;
            
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
            currentTime += Time.deltaTime;

            TextHolder.SetActive(true);
            float timeLeft = Mathf.Max(0f,OOBTimeLimit - currentTime);
            float alpha = timeLeft - Mathf.Floor(timeLeft);

            CountdownText.text = Mathf.CeilToInt(timeLeft).ToString();
            Color textColour = CountdownText.color;
            textColour.a = alpha;
            CountdownText.color = textColour;

        }
        else
        {
            currentTime -= Time.deltaTime * 0.5f;

            currentTime = Mathf.Max(currentTime, 0f);
        }

        if(currentTime >= OOBTimeLimit)
        {
            timer.currentTime += 60f;
            Player.transform.position = SpawnPoint.transform.position;
            currentTime = 0f;
            playerInZone = false;
            TextHolder.SetActive(false);
        }
    }
}
