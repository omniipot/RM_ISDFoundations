using System.Collections;
using UnityEngine;

public class KeyDetectionTrigger : MonoBehaviour
{
    public Animator key1Animator;
    public Animator key2Animator;
    public Animator barrier1Animator;
    public Animator barrier2Animator;

    private bool sequence1Play = false;
    private bool sequence2Play = false;

    public bool Key1Inserted = false;
    public bool Key2Inserted = false;

    public PlayerDetection playerDetection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetection.hasKey1  && sequence1Play == false)
        {
            sequence1Play = true;
            StartCoroutine(PlaySequence(key1Animator, "Key1Fall", barrier1Animator, "Barrier1Fall"));
            Key1Inserted = true;
        }
    

    if (playerDetection.hasKey2  && sequence2Play == false)
        {
            sequence2Play = true;
            StartCoroutine(PlaySequence(key2Animator, "Key2Fall", barrier2Animator, "Barrier2Fall"));
            Key2Inserted = true;

       }
    }
    private IEnumerator PlaySequence(
        Animator keyAnimator, string KeyAnimation,
        Animator barrierAnimator, string barrierAnimation)
    {
        keyAnimator.Play(KeyAnimation,0,0f);

        yield return WaitForAnimation(keyAnimator, KeyAnimation);

        barrierAnimator.Play(barrierAnimation,0,0f);

    }
     private IEnumerator WaitForAnimation(Animator animator, string stateName)
     {
     yield return null;
     while (!animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
        {
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }
    }
     
}
