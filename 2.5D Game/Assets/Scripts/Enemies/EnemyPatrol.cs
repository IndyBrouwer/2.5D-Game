using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform wallCheck;
    public float rayDistance = 0.5f;
    public LayerMask wallLayer;

    private bool movingRight = true;

    private void FixedUpdate()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        Vector2 direction;
        if (movingRight)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        //Make the ray visible in the Scene view
        Debug.DrawRay(wallCheck.position, direction * rayDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(wallCheck.position,direction, out hit, rayDistance, wallLayer) && hit.collider != null)
        {
            movingRight = !movingRight;

            // Flip the sprite
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            Debug.Log("Wall detected: " + hit.collider.name);
        }
    }    
}
