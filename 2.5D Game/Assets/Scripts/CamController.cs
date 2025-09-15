using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}