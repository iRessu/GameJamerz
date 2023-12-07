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
    public int requiredDigits;

    public GameObject assoicateDoor;
  
    

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if(codeTextValue == requiredValue)
        {
            assoicateDoor.GetComponent<DoorScript>().UnlockDoor();
        }

        if(codeTextValue.Length >= requiredDigits)
        {
            codeTextValue = "";
        }
    }


    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
