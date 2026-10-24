using System.Collections.Generic;


using Microsoft.Unity.VisualStudio.Editor;
using Unity.VectorGraphics;
using UnityEditor.PackageManager;
using UnityEngine;
// this script is the main way that all of the puzzle codes get randomized correctly and put inside the keypads.

// this majority just reuses the same code over and over again but i didnt want to put it in seperate files 
public class PuzzleManager : MonoBehaviour
{
    public Keypad ShapePuzzle;
    public Keypad ColourPuzzle;
    public Keypad MixedPuzzle;

    public Sprite[] NumberSprites;

    private Dictionary<string, int> symbShapes = new Dictionary<string, int>();

    public Transform[] paintingSlots;
    public GameObject[] paintingShapes;
    

    private Dictionary<string,int> symbColours = new Dictionary<string, int>();

    public Transform[] bookSlots;
    public GameObject[] bookColours;

    private readonly string[] MixedAnswer = //string is readonly as to prevent anything from changing it that's not mean't to
    // it also generates the mixed answer code
    {
        "Triangle",
        "Square",
        "Red",
        "Green",
        "Purple",
        "Circle"
    };

    // number images

    public UnityEngine.UI.Image CircleImage;
    public UnityEngine.UI.Image triangleImage;
    public UnityEngine.UI.Image squareImage;
    public UnityEngine.UI.Image redImage;
    public UnityEngine.UI.Image blueImage;
    public UnityEngine.UI.Image greenImage;
    public UnityEngine.UI.Image yellowImage;
    public UnityEngine.UI.Image purpleImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateMapping();
        randomizePaintings();
        randomizeBooks();
        
        squareImage.sprite = NumberSprites[symbShapes["Square"]];
        CircleImage.sprite = NumberSprites[symbShapes["Circle"]];
        triangleImage.sprite = NumberSprites[symbShapes["Triangle"]];

        redImage.sprite = NumberSprites[symbColours["Red"]];
        blueImage.sprite = NumberSprites[symbColours["Blue"]];
        greenImage.sprite = NumberSprites[symbColours["Green"]];
        yellowImage.sprite = NumberSprites[symbColours["Yellow"]];
        purpleImage.sprite = NumberSprites[symbColours["Purple"]];


        string shapeCode = GenerateShapeCode();
        ShapePuzzle.SetCode(shapeCode);
        string colourCode = GenerateColourCode();
        ColourPuzzle.SetCode(colourCode);
        string mixedCode = GenerateMixedCode();
        MixedPuzzle.SetCode(mixedCode);

        Debug.LogWarning("Shape keypad Code:"+ shapeCode);
        Debug.LogWarning("Colour keypad Code:"+ colourCode);
        Debug.LogWarning("Mixed keypad Code:" + mixedCode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateMapping()
    {
        symbShapes.Clear();
        List<int> numbers = new List<int>
        {
            0,1,2,3,4,5,6,7,8,9
        };
        // fills out a list of numbers and then assigns numbers to them randomly ensuring there is no doubles.
        for (int i = 0; i < numbers.Count; i++)
        {
            int randomIndex = Random.Range(i, numbers.Count); // 

            int temp = numbers[i];
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;

        }
        symbShapes["Circle"] = numbers[0];
        symbShapes["Triangle"] = numbers[1];
        symbShapes["Square"] = numbers[2];

        symbColours["Red"] = numbers[3];
        symbColours["Blue"] = numbers[4];
        symbColours["Green"] = numbers[5];
        symbColours["Yellow"] = numbers[6];
        symbColours["Purple"] = numbers[7];
        
        Debug.Log("Puzzles Map Done Sir!");
        foreach (var entry in symbShapes)
        {
            Debug.LogWarning(entry.Key + "=" + entry.Value);
        }
        foreach (var entry in symbColours)
        {
            Debug.LogWarning(entry.Key + "=" + entry.Value);
        }
    }   

    void randomizePaintings()

    // creates a list of how many paintings there are to shuffle and how many slots, then randomizes the  painting order)
    {   
        Debug.Log("RandomisePaintings was called!");
        Debug.Log("Paintings: " + paintingShapes.Length);
        Debug.Log("Slots: " + paintingSlots.Length);

        List<GameObject> paintingShuffled = new List<GameObject>(paintingShapes);

        for (int i = 0; i < paintingShuffled.Count; i++)
        {
            int randomIndex = Random.Range(
                i, paintingShuffled.Count
            );

            GameObject temp = paintingShuffled[i];
            paintingShuffled[i] = paintingShuffled[randomIndex];
            paintingShuffled[randomIndex]= temp;

        
        }
        paintingShapes = paintingShuffled.ToArray();
        for (int i = 0; i < paintingShuffled.Count; i++) 
        {
            
            paintingShuffled[i].transform.SetPositionAndRotation(
                paintingSlots[i].position, paintingSlots[i].rotation
            );
        }
    
    }
    string GenerateShapeCode()
    {
        string code = ""; 

        foreach (GameObject painting in  paintingShapes)
        {
            PaintingClue clue = painting.GetComponent<PaintingClue>();

            if (clue == null)
            {
                Debug.LogError("FIX YOUR SHIT NO PAINTING CLUE ON" + painting.name);
                return "";

            }

            code += symbShapes[clue.shapeName].ToString(); // ensures that the painting positions
            //  adds the number assigned to the paintings shape to the code ensuring a matched painting order

        }

        return code;
    }

    void randomizeBooks()
    // same idea as the paintings
    {
         List<GameObject> bookShuffled = new List<GameObject>(bookColours);

        for (int i = 0; i < bookShuffled.Count; i++)
        {
            int randomIndex = Random.Range(
                i, bookShuffled.Count
            );

            GameObject temp = bookShuffled[i];
            bookShuffled[i] = bookShuffled[randomIndex];
            bookShuffled[randomIndex]= temp;

        
        }
        bookColours = bookShuffled.ToArray();
        for (int i = 0; i < bookShuffled.Count; i++)
        {
            
            bookShuffled[i].transform.SetPositionAndRotation(
                bookSlots[i].position, bookSlots[i].rotation
            );
        }
    
    }
    string GenerateColourCode()
    {
        {
        string code = "";

        foreach (GameObject colour in bookColours)
        {
            BookClue clue = colour.GetComponent<BookClue>();

            if (clue == null)
            {
                Debug.LogError("FIX YOUR SHIT NO PAINTING CLUE ON" + colour.name);
                return "";

            }

            code += symbColours[clue.colourName].ToString(); // same idea as the paintings

        }

        return code;
    }
    }
    string GenerateMixedCode()
    {
        string code = "";
    
       foreach (string symbol in MixedAnswer) // assigns the code based off the preset code and the numbers that have been currently set
        {
            int value;

            if (symbShapes.TryGetValue(symbol, out value))
            {
                code += value.ToString();
            }
            else if (symbColours.TryGetValue(symbol, out value))
            {
                code += value.ToString();
            };
            
            
        }
        return code;
    }

    
}

    

    

    

    

 
