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

    public GameObject assoicateDoor;
  
    

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if(codeTextValue == requiredValue)
        {
            assoicateDoor.GetComponent<DoorScript>().UnlockDoor();
        }

        if(codeTextValue.Length >= 5)
        {
            codeTextValue = "";
        }
    }


    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

    public void PlaySound()
    {
        AudioManager am = FindObjectOfType<AudioManager>();
        am.Play("Button_Push");
    }
}
