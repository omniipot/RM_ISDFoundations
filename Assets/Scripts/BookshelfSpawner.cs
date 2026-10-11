using JetBrains.Annotations;
using UnityEngine;
// this script is to spawn bookshelfs at random locations to add to the randomness of the level
public class BookshelfSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;

    public GameObject Bookshelf;

    public int chosenSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      chosenSpawnPoint = Random.Range(0,spawnPoints.Length);
      Bookshelf.transform.position = spawnPoints[chosenSpawnPoint].position;
      Bookshelf.transform.rotation = spawnPoints[chosenSpawnPoint].rotation;
    

    }



 
    // Update is called once per frame
    void Update()
    {
        
    }
}
