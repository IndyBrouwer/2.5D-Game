using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 3f, transform.position.z);
    }
}