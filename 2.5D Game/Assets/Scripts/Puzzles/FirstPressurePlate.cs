using UnityEngine;

public class FirstPressurePlate : MonoBehaviour
{
    public PressurePlates pressurePlatesScript;
    [SerializeField] private GameObject redButton;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressurePlatesScript.FirstPressed = true;
            redButton.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressurePlatesScript.FirstPressed = false;
            redButton.SetActive(true);
        }
    }
}
