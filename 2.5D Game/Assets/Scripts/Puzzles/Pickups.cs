using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    [SerializeField] private RawImage gemImage;

    [SerializeField] private Texture GemCollected;
    [SerializeField] private Texture GemNotCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            gemImage.texture = GemCollected;
        }
    }
}