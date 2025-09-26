using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCheck : MonoBehaviour
{
    [Header("Ground Check Settings")]
    public LayerMask groundLayer;
    public LayerMask waterLayer;    

    public bool isGrounded = false;
    private float checkDistance = 0.1f;

    private void FixedUpdate()
    {
        Vector3 playerPosition = transform.position;

        if (Physics.Raycast(playerPosition, Vector3.down, out RaycastHit hitInfo, checkDistance, groundLayer))
        {
            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground") || hitInfo.collider.CompareTag("Crate"))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

        }
        else if (Physics.Raycast(playerPosition, Vector3.down, out hitInfo, checkDistance, waterLayer))
        {
            if (hitInfo.collider.CompareTag("Water"))
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            isGrounded = false;
        }

        //Debug line in the Scene view so you can see the ray
        Color rayColor = Color.red;
        Debug.DrawRay(playerPosition, Vector3.down * checkDistance, rayColor);

        //Debug messages to see what the ray is seeing
       Debug.Log("Is Grounded: " + isGrounded);
    }
}