using UnityEngine;
using UnityEngine.SceneManagement;
// this loads the game 
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
        SceneManager.LoadSceneAsync(2);
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
