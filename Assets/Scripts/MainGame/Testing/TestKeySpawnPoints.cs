// this script is used to text the spawn points for objects to see how they display inside them.
using UnityEngine;

public class TestKeySpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private string spawnPointTag = "KeySpawnPoint";

    void Start()
    {
        Transform[] allChildren =
            GetComponentsInChildren<Transform>(true);

        int count = 0;

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(spawnPointTag))
            {
                GameObject key = Instantiate(
                    keyPrefab,
                    child.position,
                    child.rotation
                );
                key.transform.localScale = keyPrefab.transform.localScale;
                count++;
            }
        }

        Debug.Log($"Spawned {count} test keys.");
    }
}
