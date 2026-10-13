using System.Collections;
using UnityEngine;
// this script will play animations for if you have key 1 or key 2, and you pass by a trigger
public class KeyDetectionTrigger : MonoBehaviour
{
    public Animator key1Animator;
    public Animator key2Animator;
    public Animator barrier1Animator;
    public Animator barrier2Animator;
    public Animator DoorAnimator;

    public CompletionCheck completionCheck;

    private bool sequence1Play = false;
    private bool sequence2Play = false;

    public bool Key1Inserted = false;
    public bool Key2Inserted = false;

    public PlayerDetection playerDetection;
    public GameObject Door;
    public Collider doorCollider;

    public bool playerInZone = false;

    private bool doorAnimationStarted = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && playerDetection.hasKey1  && sequence1Play == false)
        {
            sequence1Play = true;
            StartCoroutine(PlaySequence(key1Animator, "Key1Fall", barrier1Animator, "Barrier1Fall"));
            Key1Inserted = true;
        }
    

        if (playerInZone && playerDetection.hasKey2  && sequence2Play == false)
        {
            sequence2Play = true;
            StartCoroutine(PlaySequence(key2Animator, "Key2Fall", barrier2Animator, "Barrier2Fall"));
            Key2Inserted = true;

       }
       if (completionCheck.DoorOpen && !doorAnimationStarted)
        {   
            doorAnimationStarted = true;
            Debug.LogWarning("Door Is Open!");
            doorCollider.enabled = false;
            DoorAnimator.Play("DoorOpen",0,0f);
            // then play door opening animation
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
        }
    }
     


