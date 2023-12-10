using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject doorTrigger;
    [SerializeField] private GameObject dialougeBox;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            doorTrigger.SetActive(true);
            key.SetActive(false);
            Destroy(dialougeBox);
        }
    }
}
