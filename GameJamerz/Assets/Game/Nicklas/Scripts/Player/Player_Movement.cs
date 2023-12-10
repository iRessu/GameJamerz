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

    private string currentAnimation;
    private int lastDirection = 0;

    Animator anim;
    const string PLAYER_WALKUP = "PlayerWalkUp_AN";
    const string PLAYER_WALKDOWN = "PlayerWalkDown_AN";
    const string PLAYER_WALKRIGHT = "PlayerWalkRight_AN";
    const string PLAYER_WALKLEFT = "PlayerWalkLeft_AN";
   
    const string PLAYER_IDLEDUP = "PlayerIdleUp_AN";
    const string PLAYER_IDLEDOWN = "PlayerIdleDown_AN";
    const string PLAYER_IDLEDRIGHT = "PlayerIdleRight_AN";
    const string PLAYER_IDLELEFT = "PlayerIdleLeft_AN";
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
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
      
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
      PlayDirectionalAnimation();
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
            activeDoor = col.gameObject;
            activeDoor.GetComponent<DoorScript>().HideCodePanel();
            activeDoor = null;
            Debug.Log("Exited Door Trigger");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
   

        if(collision.gameObject.tag == "Box")
        {
            Rigidbody2D boxRigidB = collision.gameObject.GetComponent<Rigidbody2D>();
            boxRigidB.velocity = Vector2.zero;
        }
    }

    private void PlayDirectionalAnimation()
    {
         if(moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            angle = (angle < 0) ? angle + 360: angle;

            int direction = (int)((angle + 45f) / 90f) % 4;

            switch(direction)
            {
                case 0:
                    ChangeAnimationState(PLAYER_WALKRIGHT);
                    break;

                case 1:
                    ChangeAnimationState(PLAYER_WALKUP);
                    break;
                case 2:
                    ChangeAnimationState((PLAYER_WALKLEFT));
                    break;
                case 3:
                    ChangeAnimationState((PLAYER_WALKDOWN));
                    break;
            }
            lastDirection = direction;
         }

         else
        {
            switch(lastDirection)
            {
                case 0:
                    ChangeAnimationState(PLAYER_IDLEDRIGHT);
                    break;

                case 1:
                    ChangeAnimationState(PLAYER_IDLEDUP);
                    break;
                case 2:
                    ChangeAnimationState((PLAYER_IDLELEFT));
                    break;
                case 3:
                    ChangeAnimationState((PLAYER_IDLEDOWN));
                    break;
            }
        }

    }

    private void DirectionalMovement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = moveInput * walkSpeed;
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimation == newState) return;
        anim.Play(newState);
    }


}
 