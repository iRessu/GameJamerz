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
    public GameObject destroyDialogue;
  
    

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if(codeTextValue == requiredValue)
        {
            assoicateDoor.GetComponent<DoorScript>().UnlockDoor();
            AudioManager.FindObjectOfType<AudioManager>().Play("Right_Code");
            Destroy(destroyDialogue);
        }

        if(codeTextValue.Length >= 5)
        {
            AudioManager.FindObjectOfType<AudioManager>().Play("Wrong_Code");
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
