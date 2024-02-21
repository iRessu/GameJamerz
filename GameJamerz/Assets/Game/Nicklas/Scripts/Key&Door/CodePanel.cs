using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CodePanel : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI codeText;
    string codeTextValue = "";
    public string requiredValue;

    public GameObject assoicateDoor;
    public GameObject destroyDialogue;

    
    private bool isWrongSoundPlaying;
    private bool canType = true;
    private int maxCodeLength = 5;
 

    private void OnEnable()
    {
        ResetValue();
    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if(e.isKey && e.type == EventType.KeyDown && canType)
        {
          switch(e.keyCode)
            {
                case KeyCode.Return:
                case KeyCode.KeypadEnter:
                        ConfirmButton();
                    break;
                case KeyCode.Backspace:
                    if(!string.IsNullOrEmpty(codeTextValue))
                    {
                        ResetValue();
                    }
                    break;
                default:
                    if (canType && char.IsDigit(e.character) && codeTextValue.Length < maxCodeLength)
                    {
                        codeTextValue += e.character;
                        PlaySound();
                    }
                    break;
            }
        }
    }


    IEnumerator ShowText(string text)
    {
        canType = false;
        isWrongSoundPlaying = true;
        AudioManager.FindObjectOfType<AudioManager>().Play("Wrong_Code");
        codeTextValue = text;
        codeText.color = Color.red;
        yield return new WaitForSeconds(1.5f);
        codeTextValue = "";
        codeText.color = Color.white;
        isWrongSoundPlaying = false;
        canType = true;
    }

    public void ConfirmButton()
    {
        if(codeTextValue.Length == 5)
        {
            if (codeTextValue == requiredValue)
            {
                assoicateDoor.GetComponent<DoorScript>().UnlockDoor();
                AudioManager.FindObjectOfType<AudioManager>().Play("Right_Code");
                Destroy(destroyDialogue);

            }
          else
            {
                StartCoroutine(ShowText("WRONG"));
            }
        }
        else
        {
            StartCoroutine(ShowText("ERROR"));
        }
      
    }
    public void ResetValue()
    {
        codeTextValue = "";
        canType = true;
        codeText.color = Color.white;
    }
    public void AddDigit(string digit)
    {
       if(canType == true)
        {
            codeTextValue += digit;
        }
       
    }

    public void PlaySound()
    {
        if (canType == true)
        {
            AudioManager am = FindObjectOfType<AudioManager>();
            am.Play("Button_Push");
        }
        
    }
}
