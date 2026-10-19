
using NUnit.Framework;
using UnityEngine;
// this script wil handle the interaction and opening and closing of the animations for OpenableObjects
public class OpenObject : MonoBehaviour
{
    private Animator anim;

    public Collider frontInteractionCollider;
    public bool Interactable = true;

    public AudioClip Open;
    public AudioClip Close;
    public AudioSource SFXSource;

    public void DisableInteractionCollider()
    {
        frontInteractionCollider.enabled = false;
        Interactable = false;
    }

    public void EnableInteractionCollider()
    {
        frontInteractionCollider.enabled = true;
        Interactable = true;
    }
    
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
        PlayOpen();
    }

    // Called by an Animation Event at the end of the animation
    public void AnimationFinished()
    {
        playClose();
        isAnimating = false;
    }

    void PlayOpen()
    {
        SFXSource.PlayOneShot(Open);
    }
    

    void playClose()
    {
        SFXSource.PlayOneShot(Close);
    }
    
}
