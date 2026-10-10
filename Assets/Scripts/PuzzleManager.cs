using System.Collections.Generic;
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

        string shapeCode = GenerateShapeCode();
        ShapePuzzle.SetCode(shapeCode);

        Debug.LogWarning("Shape keypad Code:"+ shapeCode);
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

        symbNumbers["Red"] = numbers[3];
        symbNumbers["Blue"] = numbers[4];
        symbNumbers["Green"] = numbers[5];
        symbNumbers["Yellow"] = numbers[6];
        symbNumbers["Purple"] = numbers[7];
        
        Debug.Log("Puzzles Map Done Sir!");
        foreach (var entry in symbNumbers)
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
        for (int i = 0; i < bookShuffled.Count; i++)
        {
            
            bookShuffled[i].transform.SetPositionAndRotation(
                bookSlots[i].position, bookSlots[i].rotation
            );
        }
    
    }
    }

    

    

 
