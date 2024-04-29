using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Controls controls;
    private Vector2 moveInput;

    public Transform groundCheck;
    private bool grounded;
    private LayerMask groundLayerMask;

    public float speed = .5f;
    private float yVelocity;

    // Start is called before the first frame update
    void Awake()
    {

        controls = new Controls();
        groundLayerMask = LayerMask.GetMask("Ground");

        yVelocity = 0;

        Enable();

        //controls.PlayerMovement.Jump.canceled += _ => OnJumpUpInput();   // Figure out how to do GetKeyUp with new input system
        //controls.Player.Dash.performed += _ => OnDashInput();

    }

    private void Enable()
    {
        controls.Player.Move.Enable();
        controls.Player.Jump.Enable();

        controls.Player.Jump.performed += _ => Jump();

    }

    private void Disable()
    {
        controls.Player.Move.Disable();
        controls.Player.Jump.Disable();

        controls.Player.Jump.performed -= _ => Jump();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        moveInput = controls.Player.Move.ReadValue<Vector2>();
        //Debug.Log("Move " + moveInput.x * speed);
        transform.position += new Vector3(moveInput.x * speed, 0, 0);

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, Mathf.Abs(yVelocity) + .1f, groundLayerMask);
        if (hit.collider != null && yVelocity <= 0)
        {
            
            if(yVelocity * -1 >= hit.distance)
            {
                transform.position += new Vector3(0, -hit.distance, 0);
                yVelocity = 0;
                grounded = true;
            }
            
        }
        else
        {
            grounded = false;
        }

        if (yVelocity > -3 && !grounded)
        {
            yVelocity -= .8f * Time.fixedDeltaTime;
        }

        transform.position += new Vector3(0, yVelocity, 0);

    }

    private void Jump()
    {
        if(grounded)
        {
            yVelocity += .4f;
        }
    }
}
