using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    private Slider slider;
    public float startTime;

    public Text messageBox;
    private LevelManager levelManager;
    public AudioClip winSound;
    private bool isGameWon = false;
    private float winTime;


	void Start () {
        slider = GetComponent<Slider>();
        levelManager = FindObjectOfType<LevelManager>();
        slider.maxValue = startTime;
	}
	
	void Update () {

        slider.value = startTime - Time.timeSinceLevelLoad;

        if(slider.value <= 0)
        {
            WinGame();
        }
	}

    private void WinGame()
    {
        if (!isGameWon)
        {
            AudioSource.PlayClipAtPoint(winSound, transform.position, PlayerPrefsManager.GetMasterVolume());
            messageBox.gameObject.SetActive(true);
            messageBox.text = "A Winner is you!";
            Invoke("LoadNextLevel", winSound.length);
            isGameWon = true;
            DestroyAllTagedObjects();
        }
    }

    private static void DestroyAllTagedObjects()
    {
        GameObject[] thingsToDestroy = GameObject.FindGameObjectsWithTag("DestroyOnWin");
        foreach (GameObject thisGameObject in thingsToDestroy)
        {
            Destroy(thisGameObject);
        }
    }

    private void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
