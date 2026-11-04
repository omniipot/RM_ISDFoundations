using UnityEngine;
using TMPro;
// this script is for fun facts that will be displayed in the game
public class FunFacts : MonoBehaviour
{
    public TMP_Text funFactText;
    public string[] funFacts;
    public int currentFactIndex = 0;
    public int fakeIndex = 0;
    public int randomIndex;
    public TMP_Text topText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomIndex = Random.Range(0, funFacts.Length);
        funFactText.text = funFacts[randomIndex];
        fakeIndex = Random.Range(0, 999);
        topText.text = "Fun Fact #" + (fakeIndex + 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
