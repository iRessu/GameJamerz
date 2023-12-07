using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [SerializeField] private float walkSpeed;

    public List<GameObject> doors;
    private GameObject activeDoor;
    // Start is called before the first frame update

    private void Awake()
    {
        foreach (var door in doors)
        {
            door.GetComponent<DoorScript>().LockDoor();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
      if(activeDoor != null && activeDoor.GetComponent<DoorScript>().IsDoorLocked())
        {
            activeDoor.GetComponent<DoorScript>().ShowCodePanel();
        }
      else
        {
            foreach(var door in doors)
            {
                var doorScript = door.GetComponent<DoorScript>();
                if(doorScript != null && !doorScript.IsDoorLocked())
                {
                    doorScript.HideCodePanel();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        DirectionalMovement();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Door"))
        {
            activeDoor = col.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Door"))
        {
            activeDoor = null;
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
 