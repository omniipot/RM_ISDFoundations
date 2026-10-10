using UnityEngine;

public class SpawningOpenables : MonoBehaviour
{
     [SerializeField]private Transform[] SpawnPoints;

     [SerializeField] private GameObject[] objectPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame



    private void SpawnObjects()
{   Debug.Log("SpawnObjects called on: " + gameObject.name);
    if (objectPrefabs == null || objectPrefabs.Length == 0)
    {
        Debug.LogWarning("No object prefabs assigned!");
        return;
    }

    if (SpawnPoints == null || SpawnPoints.Length == 0)
    {
        Debug.LogWarning("No spawn points assigned!");
        return;
    }

    foreach (Transform spawnPoint in SpawnPoints)
    {
        if (spawnPoint == null)
            continue;

        int randomIndex = UnityEngine.Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];
        
        Debug.LogWarning("Spawner: " + gameObject.name +
          " | Point: " + spawnPoint.name +
          " | Position: " + spawnPoint.position);

        Instantiate(
            selectedPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }

    FindFirstObjectByType<KeySpawnManager>().SpawnKeys();
}
    void Update()
    {
        
    }
}
