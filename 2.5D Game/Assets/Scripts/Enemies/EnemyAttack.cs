using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private float checkDistance = 0.1f;

    private void FixedUpdate()
    {
        Vector3 enemyPosition = transform.position;

        if (Physics.Raycast(enemyPosition, Vector3.right, out RaycastHit hitInfo, checkDistance, playerLayer))
        {
            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                //Damage player

                //Redirect to function to change player color to red on damage
            }
        }
    }
}
