using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int itemCount;


    public void ItemPickUp()
    {
        itemCount++;
        Debug.Log("Picked Up Item");
    }

    public void UseItem()
    {
        itemCount--;
    }
}
