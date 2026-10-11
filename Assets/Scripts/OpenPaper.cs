using UnityEngine;
// this script will open the bits of paper on the screen, and also handle the logic for determining what 
// image to use for each number.
public class OpenPaper : MonoBehaviour
{
    public GameObject PaperPainting;
    public GameObject PaperBook;


    public float paperDisplayTime = 12f;

    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PaperPainting.SetActive(false);
        PaperBook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PaperPainting.activeSelf == true || PaperBook.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PaperPainting.SetActive(false);
                PaperBook.SetActive(false);
            }
        }
    }

    public void OpenPaperPainting()
    {

        CancelInvoke(nameof(closePaper));
        Debug.LogWarning("OpenPainting has Run!");
        PaperPainting.SetActive(true);
        Invoke(nameof(closePaper), paperDisplayTime);
        
    }

    public void OpenPaperBook()
    {   
        
        CancelInvoke(nameof(closePaper));
        Debug.LogWarning("OpenPainting has Run!");
        PaperBook.SetActive(true);
        Invoke(nameof(closePaper), paperDisplayTime);
    }
    
    public void closePaper()
    {
        PaperPainting.SetActive(false);
        PaperBook.SetActive(false);
    }

}
