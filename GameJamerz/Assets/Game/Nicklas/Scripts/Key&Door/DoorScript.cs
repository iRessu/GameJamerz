using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel;
    [SerializeField]
    GameObject closedDoor, openedDoor;

    private bool isLocked = true;
    
    
    public void UnlockDoor()
    {
        isLocked = false;
        codePanel.SetActive(false);
        closedDoor.SetActive(false);
        openedDoor.SetActive(true);
    }

   public void LockDoor()
    {
        isLocked = true;
        codePanel.SetActive(false);
        closedDoor.SetActive(true);
        openedDoor.SetActive(false);
    }

    public bool IsDoorLocked()
    {
        return isLocked;
    }

    public void ShowCodePanel()
    {
        codePanel.SetActive(true);
        Cursor.visible = true;
        Debug.Log("CodePanel Active");
    }

    public void HideCodePanel()
    {
        Cursor.visible = false;
        codePanel.SetActive(false);
        Debug.Log("CodePanel hidden");
    }
}
