using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class TimedPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;

    [SerializeField] private float waitTime = 3f;
    [SerializeField] private GameObject redButtonPart;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip timerSound;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            redButtonPart.SetActive(false);
            StartCoroutine(MovePlatform());

            //Play timer audio
            StartCoroutine(PlayAudioTwice());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        redButtonPart.SetActive(true);
    }

    private IEnumerator MovePlatform()
    {
        platform1.SetActive(true);
        platform2.SetActive(true);

        //Wait for x amount of seconds
        yield return new WaitForSeconds(waitTime);

        //Restore start position of platform
        platform1.SetActive(false);
        platform2.SetActive(false);
    }

    private IEnumerator PlayAudioTwice()
    {
        //Set prefered audio as the play sound
        audioSource.clip = timerSound;

        //Play timer tics first time
        audioSource.Play();

        //Wait for first few timer tics to finish
        yield return new WaitForSeconds(audioSource.clip.length);

        //Play audio again to "extent" the audio
        audioSource.Play();
    }
}
