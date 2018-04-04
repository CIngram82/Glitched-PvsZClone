﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    private GameObject parent;
	// Use this for initialization
	void Start () {
        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
	}
	
    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWordPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        Defender defender = Instantiate (Button.selectedDefender);
        defender.transform.parent = parent.transform;
        defender.transform.position = roundedPos;

    }

    Vector2 SnapToGrid(Vector2 mousePos)
    {
        Vector2 mousePosOnGrid = new Vector2();
        mousePosOnGrid.x = Mathf.RoundToInt(mousePos.x);
        mousePosOnGrid.y = Mathf.RoundToInt(mousePos.y);

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
