
using UnityEngine;
// this script will assign the plauer a rank which will be displayed on the end screen
public class RankingSystem : MonoBehaviour
{
    public string CalculateRank(float time)
    {
        if (time < 150f)
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
        else if (time < 400f)
        {
            return "C";
        }
        else
        {
            return "D";
        }
    }
}
