using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private Image[] heartImages; //UI player health images
    [SerializeField] private Sprite FullHeart;
    [SerializeField] private Sprite HalfHeart;
    [SerializeField] private Sprite EmptyHeart;

    [Header("HP Settings")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float checkRadius = 1f;

    private float currentHealth;
    private bool hasTakenDamageThisFrame = false;

    // #FB7171 (Red hex for damage color)

    private void Start()
    {
        currentHealth = 2f;
    }

    private void FixedUpdate()
    {
        Vector3 playerPosition = transform.position;

        Collider[] hits = Physics.OverlapSphere(playerPosition, checkRadius, enemyLayer);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if (hasTakenDamageThisFrame)
                {
                    return;
                }

                // Damage player here
                Debug.Log("Player took damage from enemy!");

                currentHealth -= 0.5f;

                // Redirect to function to change player color to red on damage
                //ChangePlayerColor(Color.red);

                UpdatePlayerHealth();

                hasTakenDamageThisFrame = true;
                StartCoroutine(Invincibility());
            }
        }
    }

    // Draw sphere in Scene view for debugging of enemy touch
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

    private void UpdatePlayerHealth()
    {
        float healthLeft = currentHealth;

        //If player ran out of HP, go to game over screen
        if (healthLeft <= 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
        
        //Assign correct images on UI for current health
        for (int index = 0; index < heartImages.Length; index++)
        {
            if (healthLeft >= 1f)
            {
                heartImages[index].sprite = FullHeart;
                healthLeft -= 1f;
            }
            else if (healthLeft >= 0.5f)
            {
                heartImages[index].sprite = HalfHeart;
                healthLeft -= 0.5f;
            }
            else
            {
                heartImages[index].sprite = EmptyHeart;
            }
        }
    }

    private IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(1);
        hasTakenDamageThisFrame = false;
    }
}
