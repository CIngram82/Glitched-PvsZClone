using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    private GameObject parent;
    private ManaDisplay manaDisplay;

	void Start () {
        manaDisplay = FindObjectOfType<ManaDisplay>();

        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
	}
	
    private void OnMouseDown()
    {
        if (Button.selectedDefender != null){
            Vector2 roundedPos = CalculateWordPointOfMouseClick();
            if (manaDisplay.SpendMana(Button.selectedDefender.manaCost) == ManaDisplay.Status.SUCCESS)
            {
                SpawnDefender(roundedPos);
            }
            else
            {
                Debug.Log("to little mana");
            }
        }
        else
        {
            Debug.Log("no defender selected");
        }

    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender defender = Instantiate(Button.selectedDefender);
        defender.transform.parent = parent.transform;
        defender.transform.position = roundedPos;
    }
    Vector2 SnapToGrid(Vector2 mousePos)
    {
        Vector2 mousePosOnGrid = new Vector2
        {
            x = Mathf.RoundToInt(mousePos.x),
            y = Mathf.RoundToInt(mousePos.y)
        };

        return mousePosOnGrid;
    }
    Vector2 CalculateWordPointOfMouseClick()
    {
        Camera c = Camera.main;
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 mousePos = c.ScreenToWorldPoint(weirdTriplet);
        return SnapToGrid(mousePos);
    }
}
