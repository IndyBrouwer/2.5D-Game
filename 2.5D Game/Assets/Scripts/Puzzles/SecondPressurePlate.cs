using UnityEngine;

public class SecondPressurePlate : MonoBehaviour
{
    public PressurePlates pressurePlatesScript;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            pressurePlatesScript.SecondPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            pressurePlatesScript.SecondPressed = false;
        }
    }
}
