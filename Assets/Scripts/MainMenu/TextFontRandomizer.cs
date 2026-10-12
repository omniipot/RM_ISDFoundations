using System.Collections;
using UnityEngine;
using TMPro;

public class TextFontRandomizer : MonoBehaviour
{

    public TMP_FontAsset[] FontList;
    public TMP_Text Text;

    public void ChangeFont()
    {
        
    }

    public void fontRandomizer()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PickRandomOption());
    }

    IEnumerator PickRandomOption()
    {
        while (true)
        {
            int index = Random.Range(0, FontList.Length);
            Text.font = FontList[index];
        
        }
    }

}
