using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ReactionController : MonoBehaviour
{
        [System.Serializable]
        public class Reaction
    {
        public string id;
      
        public Sprite[] frames;
        
        public float fps = 12f;

        public bool loop;
        public int priority = 10;
            
    }
        [SerializeField] private Image display;
        [SerializeField] private Reaction idle;
        [SerializeField] private Reaction[] reactions;

        private Coroutine playback;
        private int currentPriority = -1;
        private bool isIdle;


    void Start()
    {
        PlayIdle();
    }

    public void Play(string reactionID)
    {
        Reaction selected = null;

        foreach (Reaction reaction in reactions)
        {
            if (reaction.id == reactionID)
            {
                selected = reaction;
                break;
            }
        }
        if (selected == null || selected.frames == null || selected.frames.Length == 0)
            return;

        if (playback != null && !isIdle && selected.priority < currentPriority)
            return;

        
        StartReaction(selected, false);

    }

    private void StartReaction(Reaction reaction, bool idleAnimation)
    {
        if (playback != null)
            StopCoroutine(playback);

        isIdle = idleAnimation;
        currentPriority = reaction.priority;
        playback = StartCoroutine(Animate(reaction));
    }

    private IEnumerator Animate(Reaction reaction)
    {
        float delay = 1f / Mathf.Max(1f, reaction.fps);

        do
        {
            foreach (Sprite frame in reaction.frames)
            {
                if (frame != null)
                    display.sprite = frame;

                yield return new WaitForSeconds(delay);
            }
        }
        while (reaction.loop);
    

    PlayIdle();
    }
    
    private void PlayIdle()
    {
        if (idle == null || idle.frames == null || idle.frames.Length == 0 )
            return;

        idle.loop = true;
        StartReaction(idle,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
