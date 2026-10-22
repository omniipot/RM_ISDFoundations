using UnityEngine;
using UnityEngine.Analytics;
// this script is to click to trigger an animation on the object the script is attached to
public class ClickToAnimate : MonoBehaviour
{
    public GameObject ObjectToAnimate;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Object Was Clicked");
        Debug.LogWarning("Object Was Clicked");
        //Debug.LogError("Object Was Clicked");//this will stop playmode when ran
        animator.SetBool("IsClicked", true); // Destroy the object when it is clicked
    }
}
