using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    private ManaDisplay manaDisplay;
    public int manaCost = 10;

    private void Start()
    {
        manaDisplay = FindObjectOfType<ManaDisplay>();
    }
    public void AddMana(int amount)
    {
        manaDisplay.AddMana(amount);
    }
}
