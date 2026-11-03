using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
// this loads different scenes that will be called via buttons

public class MainMenu : MonoBehaviour
{
    public TMP_Text quitText;
    public int quitCount = 1;
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void playIntro()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void loading()
    {
        SceneManager.LoadSceneAsync(4);
    }

    
    public void Quit()
    {
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
