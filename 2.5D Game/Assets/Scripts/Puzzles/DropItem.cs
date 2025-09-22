using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject itemDrop;
    public Transform dropPoint;

    public bool itemDropped = false;

    public void ItemDrop()
    {
        if (!itemDropped)
        {
            Instantiate(itemDrop, dropPoint.position, Quaternion.identity);
            itemDropped = true;
        }
    }
}
