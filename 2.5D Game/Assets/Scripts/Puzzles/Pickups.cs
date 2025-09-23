using UnityEngine;


public class Pickups : MonoBehaviour
{
    private UpdateUI UpdateUIscript;

    private void Awake()
    {
        UpdateUIscript = FindFirstObjectByType<UpdateUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            UpdateUIscript.UpdateGemImage();
        }
    }
}