using UnityEngine;

public class FirstPressurePlate : MonoBehaviour
{
    public PressurePlates pressurePlatesScript;
    public GameObject plateVisual;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressurePlatesScript.FirstPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressurePlatesScript.FirstPressed = false;
        }
    }
}
