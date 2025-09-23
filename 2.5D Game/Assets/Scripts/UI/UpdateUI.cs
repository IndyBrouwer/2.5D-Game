using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private Image gemImage;

    [SerializeField] private Sprite GemCollected;
    [SerializeField] private Sprite GemNotCollected;

    public void UpdateGemImage()
    {
        gemImage.sprite = GemCollected;
    }
}
