using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// this script displays text in order on a select delay to show in order
public class Intro : MonoBehaviour
{
    public TMP_Text Text1;
    public TMP_Text Text2;
    public TMP_Text Text3;
    public TMP_Text Text4;
    public TMP_Text Text5;
    public Button PlayButton;
    
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;



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
        PlayButton.gameObject.SetActive(false);
        Image1.gameObject.SetActive(false);
        Image2.gameObject.SetActive(false);
        Image3.gameObject.SetActive(false);
        Image4.gameObject.SetActive(false);
           


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
            yield return new WaitForSeconds(0f);

            Image1.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Text2.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);

            Text3.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);

            Text4.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Text5.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Image2.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);

            Image3.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            Image4.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            PlayButton.gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            
            ;
        }
    }
}   
