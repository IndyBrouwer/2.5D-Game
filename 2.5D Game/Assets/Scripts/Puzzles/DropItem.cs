using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject itemDrop;
    public Transform dropPoint;

    public void ItemDrop()
    {
        Instantiate(itemDrop, dropPoint.position, Quaternion.identity);
    }
}
