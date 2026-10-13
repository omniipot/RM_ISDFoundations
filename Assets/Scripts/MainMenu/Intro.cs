using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public TMP_Text Text1;
    public TMP_Text Text2;
    public TMP_Text Text3;
    public TMP_Text Text4;
    public TMP_Text Text5;
    public Button PlayButton;

    public MainMenu mainMenu;
    public 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(false);
        Text3.gameObject.SetActive(false);
        Text4.gameObject.SetActive(false);
        Text5.gameObject.SetActive(false);


        StartCoroutine(PlayText());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
                {
                   mainMenu.playGame();
                }
    }

    IEnumerator PlayText()
    {
        while (true)
        {
            Text1.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Text2.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Text3.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Text4.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Text5.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            
            ;
        }
    }
}   
