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

    public GameObject Barrier1;
    public GameObject Barrier2;

    public CompletionCheck completionCheck;

    
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
                    Debug.LogWarning("Door conditions met Key1");
                    key1Animator.SetTrigger("Key1Fall");
                    Invoke("KILLBARRIER1", 1.2f); // i give up no more barrier animation it will just dissapear this thing SUCKS
                    Key1Inserted = true;
                }
    

                if (playerInZone && playerDetection.hasKey2 && !Key2Inserted )
                {
                    Debug.LogWarning("Door conditions met Key2");
                    key2Animator.SetTrigger("Key2Fall");
                    Invoke("KILLBARRIER2", 1.5f);
                    Key2Inserted = true;
        
                }
        }
    
    }
        
    

        public void KILLBARRIER1()
        {
            Destroy(Barrier1);
        }

        public void KILLBARRIER2()
        {
            Destroy(Barrier2);
        }
      

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
        }
    }
     


