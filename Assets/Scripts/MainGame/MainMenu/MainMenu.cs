using UnityEngine;
using UnityEngine.SceneManagement;
// this loads different scenes that will be called via buttons
public class MainMenu : MonoBehaviour
{

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
