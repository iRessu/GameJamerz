using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [SerializeField] private float walkSpeed;

    private Dictionary<GameObject, CodePanel> doorCodePanelMap = new Dictionary<GameObject, CodePanel>(); 

    public static bool isDoorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CodePanel[] codePanels = FindObjectsOfType<CodePanel>();
        foreach(CodePanel panel in codePanels)
        {
            GameObject associatedDoor = panel.GetAssoiciatedDoor();
            if(associatedDoor != null && !doorCodePanelMap.ContainsKey(associatedDoor))
            {
                doorCodePanelMap.Add(associatedDoor, panel);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       foreach(var pair in doorCodePanelMap)
        {
            GameObject door = pair.Key;
            CodePanel codePanel = pair.Value;

            if(codePanel != null && codePanel.IsDoorOpened())
            {
                codePanel.ClosePanel();
            }
        }
    }

    private void FixedUpdate()
    {
        DirectionalMovement();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        CodePanel codePanel;
        if(doorCodePanelMap.TryGetValue(col.gameObject, out codePanel) && !codePanel.IsDoorOpened())
        {
            codePanel.OpenPanel();
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        CodePanel codePanel;
        if(doorCodePanelMap.TryGetValue(col.gameObject, out codePanel))
        {
            codePanel.ClosePanel();
        }
    }


    private void DirectionalMovement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = moveInput * walkSpeed;
    }


}
 