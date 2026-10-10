using System;
using System.Collections.Generic;
using UnityEngine;


public class KeySpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject Key1Prefab;
    [SerializeField] private GameObject Key2Prefab;

    [SerializeField] private string Tag = "KeySpawnPoint";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame

    public void SpawnKeys()
    {
        GameObject[] taggedPoints = GameObject.FindGameObjectsWithTag(Tag);

        List<Transform> availiblePoints = new List<Transform>();

        foreach (GameObject point in taggedPoints)
        {
            availiblePoints.Add(point.transform);

        }
       

        SpawnOneKey(Key1Prefab, availiblePoints);
        SpawnOneKey(Key2Prefab, availiblePoints);
    
    }

    public void SpawnOneKey(
        GameObject keyPrefab, List<Transform> availiblePoints)
    {
        if (keyPrefab == null)
            return;

        int index = UnityEngine.Random.Range(0, availiblePoints.Count);
        Transform point = availiblePoints[index];

        availiblePoints.RemoveAt(index);

        Instantiate(keyPrefab, point.position, point.rotation);
    }

    
    void Update()
    {
        
    }
}
