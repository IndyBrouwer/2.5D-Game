using UnityEngine;

public class InteractableCheck : MonoBehaviour
{
    //Crates have to be on ground layer! As the player needs to be able to stand and jump on them.
    public LayerMask interactableLayer;

    private float checkDistance = 0.2f;

    [Header("Climbing Settings")]
    public float climbSpeed = 3f;
    private bool isClimbing = false;


    public void ClimbLadder()
    {
        Vector3 playerPosition = transform.position;

        if (Physics.Raycast(playerPosition, Vector3.right, out RaycastHit hitInfo, checkDistance, interactableLayer))
        {
            if (hitInfo.collider.CompareTag("Ladder"))
            {
                isClimbing = true;

                if (isClimbing)
                {
                    transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
                }
            }
        }
    }
}
