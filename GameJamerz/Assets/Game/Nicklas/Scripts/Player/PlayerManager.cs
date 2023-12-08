using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int itemCount;
    [SerializeField] private ItemType itemType;

    public enum ItemType
    {
        CatFood,Key
    }

    public void ItemPickUp()
    {
        itemCount++;
        Debug.Log("Picked Up Item");
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
        

    public void UseItem()
    {
        itemCount--;
    }
}
