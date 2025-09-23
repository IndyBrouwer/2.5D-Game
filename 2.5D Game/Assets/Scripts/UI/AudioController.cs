using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Win" || currentScene.name == "GameOver") 
        { 
            audioSource.Play(); 
        }
    }

    public void PlayChestAudio(AudioClip chestAudio)
    {
        audioSource.clip = chestAudio;
        audioSource.Play();
    }
}
