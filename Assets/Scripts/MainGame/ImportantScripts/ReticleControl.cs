using JetBrains.Annotations;
using UnityEngine;

public class ReticleControl : MonoBehaviour
{

    public GameObject Active;
    public GameObject Inactive;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Active.SetActive(false);
        Inactive.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReticleActive()
    {
         Active.SetActive(true);
         Inactive.SetActive(false);
    }
    public void ReticleDisable()
    {
        Active.SetActive(false);
        Inactive.SetActive(true);
    }
}
