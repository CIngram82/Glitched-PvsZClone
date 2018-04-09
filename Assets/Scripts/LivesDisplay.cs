using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesDisplay : MonoBehaviour
{
    private int currentLives = 5;
    private Text livesAmountTextDisplay;
    public enum Status { SUCCESS, FAILURE };

    private void Start()
    {
        livesAmountTextDisplay = GetComponent<Text>();
        UpdateDisplay();
    }
    public void GainLife(int amount)
    {
 
        currentLives += amount;
        UpdateDisplay();
    }

    public Status LoseLife(int amount)
    {
        if (currentLives-amount > 0)
        {
            currentLives -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }
    private void UpdateDisplay()
    {
        livesAmountTextDisplay.text = "Lives : " + currentLives.ToString();
    }
}
