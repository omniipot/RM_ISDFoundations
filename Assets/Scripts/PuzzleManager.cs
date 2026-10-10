using System.Collections.Generic;
using System.Security.Permissions;
using Unity.VectorGraphics;
using UnityEditor.PackageManager;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Keypad ShapePuzzle;
    public Keypad ColourPuzzle;
    public Keypad MixedPuzzle;

    private Dictionary<string, int> symbNumbers = new Dictionary<string, int>();

    public Transform[] paintingSlots;
    public GameObject[] paintingShapes;

    private Dictionary<string,int> symbColours = new Dictionary<string, int>();

    public Transform[] bookSlots;
    public GameObject[] bookColours;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateMapping();
        randomizePaintings();
        randomizeBooks();
        

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
        symbNumbers.Clear();
        List<int> numbers = new List<int>
        {
            0,1,2,3,4,5,6,7,8,9
        };

        for (int i = 0; i < numbers.Count; i++)
        {
            int randomIndex = Random.Range(i, numbers.Count);

            int temp = numbers[i];
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;

        }
        symbNumbers["Circle"] = numbers[0];
        symbNumbers["Triangle"] = numbers[1];
        symbNumbers["Square"] = numbers[2];

        symbColours["Red"] = numbers[3];
        symbColours["Blue"] = numbers[4];
        symbColours["Green"] = numbers[5];
        symbColours["Yellow"] = numbers[6];
        symbColours["Purple"] = numbers[7];
        
        Debug.Log("Puzzles Map Done Sir!");
        foreach (var entry in symbNumbers)
        {
            Debug.LogWarning(entry.Key + "=" + entry.Value);
        }
        foreach (var entry in symbColours)
        {
            Debug.LogWarning(entry.Key + "=" + entry.Value);
        }
    }   

    void randomizePaintings()
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

            code += symbNumbers[clue.shapeName].ToString();

        }

        return code;
    }

    void randomizeBooks()
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

            code += symbColours[clue.colourName].ToString();

        }

        return code;
    }
    }
    string GenerateMixedCode()
    {
        string code = "";
    
        int count = Mathf.Max(paintingShapes.Length, bookColours.Length);

        for (int i = 0; i < count; i++)
        {
            if (i < paintingShapes.Length)
            {
                PaintingClue painting =
                paintingShapes[i].GetComponent<PaintingClue>();

                if (painting == null || !symbNumbers.ContainsKey(painting.shapeName))
                {
                    Debug.LogWarning("Bad Painting clue in mixed");
                    return "";
                }

                code += symbNumbers[painting.shapeName].ToString();
            if (i < bookColours.Length)
            {
                BookClue book =
                    bookColours[i].GetComponent<BookClue>();

                if (book == null ||
                    !symbColours.ContainsKey(book.colourName))
                {
                    Debug.LogError("Invalid book clue in mixed code.");
                    return "";
                }

                code += symbColours[book.colourName].ToString();
            }
            }
        
        }
        return code;
    }
}

    

    

    

    

 
