using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI codeText;
    string codeTextValue = "";
    public string requiredValue;

    public GameObject assoiciatedDoor;
    private bool isDoorOpened = false;

    public void SetAssociateDoor(GameObject door)
    {
        assoiciatedDoor = door;
    }
    public GameObject GetAssoiciatedDoor()
    {
        return assoiciatedDoor;
    }

    
    public void OpenPanel()
    {
        codeText.text = codeTextValue;

        if(codeTextValue == requiredValue)
        {
            isDoorOpened = true;
        }

        if(codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }

    }

    public void ClosePanel()
    {
        codeText.text = "";
        codeTextValue = "";
        isDoorOpened = false;
    }

    public bool IsDoorOpened()
    {
        return isDoorOpened;
    }


    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
