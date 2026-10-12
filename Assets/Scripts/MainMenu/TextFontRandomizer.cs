using System.Collections;
using UnityEngine;
using TMPro;

public class TextFontRandomizer : MonoBehaviour
{

    public TMP_FontAsset[] FontList;
    public TMP_Text Text;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PickRandomOption());
    }

    // Update is called once per frame


    void ChangeFont()
    {
        if(FontList.Length == 0) 
            return;
        
        int index = Random.Range(0, FontList.Length);
        Text.font = FontList[index];
        
        
    }
    IEnumerator PickRandomOption()
    {
        while(true)
        {
            ChangeFont();

            yield return new WaitForSeconds(Random.Range(2f,6f));
        }
    }
}
