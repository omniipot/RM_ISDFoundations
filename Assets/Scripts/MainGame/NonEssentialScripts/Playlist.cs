using UnityEngine;
using TMPro;

// This script plays a playlist and displays the currently playing song to the player.
public class PlaylistController : MonoBehaviour
{
    private const float FadeInDuration = 3f;
    private const float FadeOutDuration = 5f;

    public AudioClip[] playlistClips;
    public AudioSource audioSource;
    public int currentSongIndex = 0;
    public TextMeshProUGUI songTitleText;
    public Animator textAnimator;

    private float targetVolume;

    private void Start()
    {
        if (audioSource == null || playlistClips == null || playlistClips.Length == 0)
            return;

        targetVolume = audioSource.volume;
        currentSongIndex = Random.Range(0, 6);
        PlayCurrentSong();
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

        float elapsedTime = audioSource.time;
        float remainingTime = audioSource.clip.length - elapsedTime;
        float fadeIn = Mathf.Clamp01(elapsedTime / FadeInDuration);
        float fadeOut = Mathf.Clamp01(remainingTime / FadeOutDuration);
        audioSource.volume = targetVolume * Mathf.Min(fadeIn, fadeOut);

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
        PlayCurrentSong();
    }

    private void PlayCurrentSong()
    {
        audioSource.clip = playlistClips[currentSongIndex];
        audioSource.volume = 0f;
        audioSource.Play();

        if (songTitleText != null)
            songTitleText.text = audioSource.clip.name;

        MoveText();
    }


}
