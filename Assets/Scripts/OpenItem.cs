using System.Reflection;
using UnityEngine;
// this script is used to play animations when player interacts with GameObjects with the script on it. interacting twice will play the animation in reverse.
// Additionally, it will use the playerDetection script to detect if the player is in range to interact with the object. If the player is not in range, the animation will not play.
public class OpenItem : MonoBehaviour
{

    public bool isOpened;
    public bool AnimationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // I want to set the animation to be closed at the start.


    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
