using UnityEngine;

public class RankingSystem : MonoBehaviour
{   
    public string CalculateRank(float time)
    {
        if (time < 30f)
            return "S";
        else if (time < 30f)
            return "A";
        else if (time < 30f)
            return "B";
        else if (time < 30f)
            return "C";
        else if (time < 30f)
            return "D";
        else
            return "F";
        
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
