using UnityEngine;


public class Pickups : MonoBehaviour
{
    private UpdateUI UpdateUIscript;
    private PlayerCelebrate playerScript;

    private void Awake()
    {
        UpdateUIscript = FindFirstObjectByType<UpdateUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateUIscript.UpdateGemImage();

            playerScript = other.GetComponent<PlayerCelebrate>();
            playerScript.Celebrate();

            Destroy(this.gameObject);
        }
    }
}