using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {


    private bool isSelected;
    private Button[] buttonArray;
    public Defender defender;
    public static Defender selectedDefender;

    private void Start()
    {
        buttonArray = FindObjectsOfType<Button>();
    }

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
            thisButton.isSelected = false;
        }
        isSelected = true;
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defender;
    }
}
