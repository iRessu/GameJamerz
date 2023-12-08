using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThemeController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager am = FindObjectOfType<AudioManager>();
        am.Play("Main Theme");
    }
}
