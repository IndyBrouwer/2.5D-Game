using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private Image gemImage;

    [SerializeField] private Sprite GemCollected;
    [SerializeField] private Sprite GemNotCollected;

    public void UpdateGemImage()
    {
        gemImage.sprite = GemCollected;

        StartCoroutine(WaitForEndScreen());
    }

    private IEnumerator WaitForEndScreen()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Win");
    }
}
