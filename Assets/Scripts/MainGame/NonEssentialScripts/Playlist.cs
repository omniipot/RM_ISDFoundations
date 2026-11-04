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
        audioSource.Play();

        if (songTitleText != null)
            songTitleText.text = audioSource.clip.name;

        MoveText();
    }

    private void Update()
    {
        if (audioSource == null || playlistClips == null || playlistClips.Length == 0)
            return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            Skip();
            return;
        }

        if (audioSource.clip == null || !audioSource.isPlaying)
            return;

        int bufferLength;
        AudioSettings.GetDSPBufferSize(out bufferLength, out _);
        int endMargin = Mathf.Min(
            Mathf.Max(bufferLength, audioSource.clip.frequency / 10),
            Mathf.Max(1, audioSource.clip.samples / 10));
        if (audioSource.timeSamples >= audioSource.clip.samples - endMargin)
        {
            Debug.Log("Current song finished playing. Moving to the next song in the playlist.");
            PlayNextSong();
        }
    }

    public void MoveText()
    {
        if (textAnimator == null)
            return;
        Debug.Log("Moving text to display the current song title.");
        textAnimator.Play("PlaylistAnim", 0, 0f);
    }

    public void Skip()
    {
        if (audioSource == null || playlistClips == null || playlistClips.Length == 0)
            return;

        Debug.Log("Skipping to the next song in the playlist.");
        PlayNextSong();
    }

    private void PlayNextSong()
    {
        currentSongIndex = (currentSongIndex + 1) % playlistClips.Length;
        audioSource.clip = playlistClips[currentSongIndex];
        audioSource.Play();

        if (songTitleText != null)
            songTitleText.text = audioSource.clip.name;

        MoveText();
    }


}
