using UnityEngine;

public class CursorTexture : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
   

}
