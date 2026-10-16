
using UnityEngine;
using System.Collections.Generic;
// this spawns keys inside of the availible key spawnpoints from the closets/wardrobes
public class ChildObjectSpawner : MonoBehaviour
{
    [Header("Key Prefabs")]
    [SerializeField] private GameObject[] keyPrefabs;

    [Header("Spawn Point Name")]
    [SerializeField] private string spawnPointTag = "KeySpawnPoint";

    private void Start()
    {
        // SpawnKeys();
                   Debug.Log("Spawner running on: " + gameObject.name, this);

                    Transform[] points = GetComponentsInChildren<Transform>(true);

                    foreach (Transform point in points)
                    {
                Debug.Log("Found child: " + point.name, point);
         
                     }
    }
}
    