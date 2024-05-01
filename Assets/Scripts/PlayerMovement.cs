using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public Controls controls;
    private Vector2 moveInput;

    public Transform groundCheck;
    private bool grounded;
    private LayerMask groundLayerMask;

    public float speed = .5f;
    private float yVelocity;

    public bool menuUp;
    public GameObject menu;

    [SerializeField] private CollisionManager collisionManager;
    private bool justJumped;

    // Start is called before the first frame update
    void Awake()
    {

        controls = new Controls();
        groundLayerMask = LayerMask.GetMask("Ground");

        yVelocity = 0;

        controls.Player.Menu.Enable();
        controls.Player.Menu.performed += _ => ToggleMenu();

        menuUp = false;
        justJumped = false;

        Enable();

    }

    private void Enable()
    {
        controls.Player.Move.Enable();
        controls.Player.Jump.Enable();
        controls.Player.Reset.Enable();

        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Reset.performed += _ => Reset();


    }

    private void Disable()
    {
        controls.Player.Move.Disable();
        controls.Player.Jump.Disable();
        controls.Player.Reset.Disable();

        controls.Player.Jump.performed -= _ => Jump();
        controls.Player.Reset.performed -= _ => Reset();
    }

    private void ToggleMenu()
    {
        if(menuUp)
        {
            Enable();
            menu.SetActive(false);
            menuUp = false;
        }
        else
        {
            Disable();
            menu.SetActive(true);
            menuUp = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Vector3 move = new Vector3(0, 0, 0);

        //Horizontal movement
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        move.x = moveInput.x * speed;

        //Gravity
        if(!menuUp)
        {
            move.y = yVelocity;

            if (yVelocity > -3 && !grounded)
            {
                yVelocity -= .8f * Time.fixedDeltaTime;
            }
        }

        //Die from falling
        if (transform.position.y < -22)
        {
            Reset();
        }

        Vector3 TR = transform.position + (transform.localScale / 2);

        Vector3 TL = TR;
        TL.x -= transform.localScale.x;

        Vector3 BL = transform.position - (transform.localScale / 2);

        Vector3 BR = BL;
        BR.x += transform.localScale.x;

        //Debug.Log("TR - " + TR + " TL - " + TL + " BR - " + BR + " BL - " + BL);

        if (grounded)
        {
            if(collisionManager.HorizontalCheck(TR, TL, BR, BL, new Vector3(move.x, 0, 0)))
            {
                move.x = 0;
            }
        }else
        {
            if (collisionManager.HorizontalCheck(TR, TL, BR, BL, move))
            {
                move.x = 0;
            }
        }
        if (justJumped)
        {
            justJumped = false;
        }
        else
        {
            if (collisionManager.VerticalCheck(TR, TL, BR, BL, move))
            {
                if (move.y <= 0)
                {
                    grounded = true;
                }
                else
                {
                    yVelocity = 0;
                }
                move.y = 0;
                //yVelocity = 0;
            }
            else
            {

                grounded = false;
            }
        }
        
        transform.position += move;
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Jump()
    {
        if(grounded)
        {
            yVelocity = .4f;
            grounded = false;
            justJumped = true;
            transform.position += new Vector3(0, yVelocity, 0);
        }
    }
}
