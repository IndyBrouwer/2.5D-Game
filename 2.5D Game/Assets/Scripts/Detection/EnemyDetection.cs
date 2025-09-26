using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float checkRadius = 5f;
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private float directionChangeSpeed = 3f; // higher = reacts faster
    private float currentDirection = 0f;
    private Transform targetPlayer;

    private void Start()
    {
        Vector3 enemyStartPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 enemyPosition = transform.position;
        Collider[] hits = Physics.OverlapSphere(enemyPosition, checkRadius, playerLayer);

        foreach (Collider hit in hits)
        {
            if (hits.Length > 0)
            {
                //Insert the first detected player, (1st in index is 0). To the target to move to
                targetPlayer = hits[0].transform;
            }
            else
            {
                targetPlayer = null; //If no player in detection sphere, empty the target to move to
            }

            //If a player is in detection sphere, start chasing
            if (targetPlayer != null)
            {
                ChasePlayer();
            }
        }
    }

    private void ChasePlayer()
    {
        if (targetPlayer == null)
        {
            return;
        }

        Vector3 enemyPos = transform.position;
        Vector3 playerPos = targetPlayer.position;

        //Only chase on X (ignore Z for 2.5D side movement)
        float targetDirection = Mathf.Sign(playerPos.x - enemyPos.x);

        currentDirection = Mathf.Lerp(currentDirection, targetDirection, Time.fixedDeltaTime * directionChangeSpeed);

        //Move towards the player
        transform.position += new Vector3(currentDirection * moveSpeed * Time.fixedDeltaTime, 0f, 0f);

        //Rotate enemy to player (-90 Y is look to the left, 90 Y is to the right)
        RotateTowardsPlayer(targetDirection);
    }

    private void RotateTowardsPlayer(float direction)
    {
        if (direction < 0) //player is to the left
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else if (direction > 0) //player is to the right
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize detection radius in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
