using UnityEngine;
using TMPro;

// This script plays a playlist and displays the currently playing song to the player.
public class PlaylistController : MonoBehaviour
{
    public AudioClip[] playlistClips;
    public AudioSource audioSource;
    public int currentSongIndex = 0;
    public TextMeshProUGUI songTitleText;
    public Animator textAnimator;

    private void Start()
    {
        if (playlistClips == null || playlistClips.Length == 0)
            return;

        currentSongIndex = Random.Range(0, playlistClips.Length);
        audioSource.clip = playlistClips[currentSongIndex];

        if (songTitleText != null)
            songTitleText.text = audioSource.clip.name;

        MoveText();
    }

    private void Update()
    {
        if (audioSource == null || playlistClips == null || playlistClips.Length == 0)
            return;

        if (!audioSource.isPlaying)
        {
            currentSongIndex = (currentSongIndex + 1) % playlistClips.Length;
            audioSource.clip = playlistClips[currentSongIndex];
            audioSource.Play();

            if (songTitleText != null)
                songTitleText.text = audioSource.clip.name;

            MoveText();
        }
    }

    public void MoveText()
    {
        if (textAnimator == null)
            return;

        textAnimator.Play("PlaylistAnim");
    }
}
