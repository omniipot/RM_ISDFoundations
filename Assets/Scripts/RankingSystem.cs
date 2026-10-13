
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    public string CalculateRank(float time)
    {
        if (time < 180f)
        {
            return "S";
        }
        else if (time < 240f)
        {
            return "A";
        }
        else if (time < 300f)
        {
            return "B";
        }
        else if (time < 360f)
        {
            return "C";
        }
        else
        {
            return "D";
        }
    }
}
