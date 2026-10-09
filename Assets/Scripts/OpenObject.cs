
using NUnit.Framework;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    private Animator anim;
    private bool isAnimating = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("No animator found on" + gameObject.name);
        }
    }

    public void PlayAnimation()
    {
        if (anim == null || isAnimating)
            return;

        isAnimating = true;
        anim.SetTrigger("TrOpen");
    }

    // Called by an Animation Event at the end of the animation
    public void AnimationFinished()
    {
        isAnimating = false;
    }
}
