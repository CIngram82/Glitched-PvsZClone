using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseArea : MonoBehaviour {
    private LivesDisplay livesDisplay;
    private LevelManager levelManager;

    private void Start()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (livesDisplay.LoseLife(1) == LivesDisplay.Status.FAILURE)
        {
            levelManager.LoadLevel("lose");
        }
    }

}
