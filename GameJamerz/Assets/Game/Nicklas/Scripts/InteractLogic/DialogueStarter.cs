using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
  

    public GameObject dialogueObject;
    private Dialogue dialScript;


    private void Start()
    {
        dialScript = dialogueObject.GetComponent<Dialogue>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            dialogueObject.SetActive(true);
            dialScript.StartDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            dialogueObject.SetActive(false);
        }
    }
}
