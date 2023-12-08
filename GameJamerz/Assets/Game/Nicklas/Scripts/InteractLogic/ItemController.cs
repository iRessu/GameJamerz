using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public bool isUsed;
    


    public void UseItem(GameObject obj)
    {
        if(!isUsed)
        {
            PlayerManager manager = obj.GetComponent<PlayerManager>();

            if (manager)
            {
                if (manager.itemCount > 0)
                {
                    isUsed = true;
                    manager.UseItem();
                }
            }
        }
    }

}
