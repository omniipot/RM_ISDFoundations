
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false;

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
        Debug.LogWarning("Open Signal Recieved");

        if (anim == null)
        {
            Debug.LogError("Animator is missing!! HELP ME HELP ME HELP ME");
        }

        if (isOpen == false)
        {
            Debug.LogWarning("OpeningAnimationTriggered");
            anim.SetTrigger("TrOpen");
            isOpen = true;
        }
        else
        {
                Debug.LogWarning("ClosingAnimationTriggered");
                anim.SetTrigger("TrClose");
                isOpen = false;
        }
    }
}