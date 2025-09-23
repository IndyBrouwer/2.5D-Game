using UnityEngine;

public class PlayerCelebrate : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerControllerScript = GetComponent<PlayerController>();
    }

    public void Celebrate()
    {
        //Turn off player controls
        playerControllerScript.enabled = false;
        

        //Trigger the celebration animation
        animator.SetTrigger("Celebrate");

        //Rotate player towards camera
        transform.rotation = Quaternion.Euler(0, 180f, 0);
    }
}
