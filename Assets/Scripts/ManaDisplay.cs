using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class ManaDisplay : MonoBehaviour {
    private int currentMana = 100 ;
    private Text manaAmountTextDisplay;
    public enum Status { SUCCESS, FAILURE};

    private void Start()
    {
        manaAmountTextDisplay = GetComponent<Text>();
        UpdateDisplay();
    }
    public void AddMana(int amount)
    {
        print(amount + "mana added");
        currentMana += amount;
        print("total mana :" + currentMana);
        UpdateDisplay();
    }

    public Status SpendMana(int amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }
    private void UpdateDisplay()
    {
        manaAmountTextDisplay.text = "Mana : " + currentMana.ToString();
    }
}
