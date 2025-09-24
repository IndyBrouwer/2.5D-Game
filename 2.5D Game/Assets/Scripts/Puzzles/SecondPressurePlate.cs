using UnityEngine;

public class SecondPressurePlate : MonoBehaviour
{
    public PressurePlates pressurePlatesScript;

    [SerializeField] private GameObject redButton;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            pressurePlatesScript.SecondPressed = true;
            redButton.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            pressurePlatesScript.SecondPressed = false;
            redButton.SetActive(true);
        }
    }
}
