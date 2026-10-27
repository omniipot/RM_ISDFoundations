using System.Collections;
using System.Threading;
using UnityEngine;
// this script will play animations for if you have key 1 or key 2 (NOT ENTIRELY WORKING, WILL NEED TO FIX)
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

    public AudioSource SFXSource;
    public AudioClip SlamOpen;

    public bool playerInZone = false;

    private bool doorAnimationStarted = false;

    public Light CanLeaveLight;
    public ReactionController reactionController;
    
    void Start()
    {

        CanLeaveLight.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {               //plays animation in sequence if player is in position to play the animation, to ensure that
                    // they will probably see it 
       
       if (completionCheck.DoorOpen && !doorAnimationStarted)
        {   
            doorAnimationStarted = true;
            Debug.LogWarning("Door Is Open!");
            doorCollider.enabled = false;
            DoorAnimator.Play("DoorOpen",0,0f);
            CanLeaveLight.color = Color.green;
            SFXSource.PlayOneShot(SlamOpen);
            reactionController.Play("escape");
        
        }
    }
    
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))

            playerInZone = true;
        {
            if (playerInZone && playerDetection.hasKey1 && !Key1Inserted)
        {
           key1Animator.SetTrigger("Key1Fall"); 
          
         
           
            
            Key1Inserted = true;
        }
    

        if (playerInZone && playerDetection.hasKey2 && !Key2Inserted )
        {
           key1Animator.SetTrigger("Key2Fall");

           Key2Inserted = true;
        
       }
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
     


