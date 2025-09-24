using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    public bool FirstPressed = false;
    public bool SecondPressed = false;

    public GameObject chestLid;
    [SerializeField] private AudioSource chestAudioSource;
    [SerializeField] private AudioClip itemDroppedSound;

    private DropItem dropItemScript;
    [SerializeField] private AudioController audioControllerScript;

    private void Awake()
    {
        dropItemScript = GetComponent<DropItem>();
    }

    private void FixedUpdate()
    {
        if (FirstPressed && SecondPressed)
        {
            Debug.Log("Both plates pressed!");
            //Open chest
            chestLid.transform.rotation = Quaternion.Euler(-25f, -180f, 0f); //Needs the -180 as the chest model is rotated to face the direction of the camera

            //Call in the item drop function
            dropItemScript.ItemDrop();

            //play audio
            audioControllerScript.PlayChestAudio(itemDroppedSound);
        }
    }
}
