using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    private Button[] buttonArray;
    public Defender defender;
    public static Defender selectedDefender;
    private Text manaCostText;


    private void Start()
    {
        buttonArray = FindObjectsOfType<Button>();
        SetManaCosts();
        if(name == "Mana Shrine")
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            selectedDefender = defender;
        }
    }

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;

        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defender;
    }
    private void SetManaCosts()
    {
        foreach(Button thisButton in buttonArray)
        {
            manaCostText = GetComponentInChildren<Text>();
            if (!manaCostText) Debug.Log(name + " has no  mana cost text");
            manaCostText.text = defender.manaCost.ToString();

        }
    }
}
