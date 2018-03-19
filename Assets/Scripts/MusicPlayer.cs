using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    public AudioClip[] levelMusicArray;
    private AudioSource audioSource;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        AudioClip currentLevelMusic = levelMusicArray[scene.buildIndex];
        
        if(currentLevelMusic != null)
        {
            audioSource.clip = currentLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
  
}
