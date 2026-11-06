using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
// this loads different scenes that will be called via buttons

public class MainMenu : MonoBehaviour
{
    public TMP_Text quitText;
    public int quitCount = 1;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public void playGame()
    {
        playSound();
        SceneManager.LoadSceneAsync(1);
    }

    public void playIntro()
    {
        playSound();
        SceneManager.LoadSceneAsync(3);
    }

    public void mainMenu()
    {
        playSound();
        SceneManager.LoadSceneAsync(0);
    }

    public void loading()
    {
        playSound();
        SceneManager.LoadSceneAsync(4);
    }

    public void playSound()
    {
        audioSource.PlayOneShot(buttonSound, 0.5f);
    }
    public void Quit()
    {
        playSound();
        quitText.text = "QUIT?";
        quitCount++;
        if (quitCount >= 2)
        {
            Application.Quit();
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
