using UnityEngine;

public class KeySpawning : MonoBehaviour
// this script will randomise key spawn locations based off present spawn points. the keys will spawn at random locations at the start of the game.
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] spawnPoints; // Array to hold the spawn points
    public GameObject key1Prefab; // Prefab for Key 1
    public GameObject key2Prefab; // Prefab for Key 2
    
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        // pick a random spawn point for Key 1
        int randomIndex1 = Random.Range(0, spawnPoints.Length);
        // instantiate Key 1 at the selected spawn point
        Instantiate(key1Prefab, spawnPoints[randomIndex1].transform.position, spawnPoints[randomIndex1].transform.rotation);
        //pick a random spawn point for Key 2
        int randomIndex2 = Random.Range(0, spawnPoints.Length);
        while(randomIndex1 == randomIndex2)
        {
            randomIndex2 = Random.Range(0, spawnPoints.Length);
        }
        // instantiate Key 2 at the selected spawn point
        Instantiate(key2Prefab, spawnPoints[randomIndex2].transform.position, spawnPoints[randomIndex2].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
