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

    // Start is called before the first frame update
    void Awake()
    {

        controls = new Controls();
        groundLayerMask = LayerMask.GetMask("Ground");

        yVelocity = 0;

        controls.Player.Menu.Enable();
        controls.Player.Menu.performed += _ => ToggleMenu();

        menuUp = false;

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

        moveInput = controls.Player.Move.ReadValue<Vector2>();
        //Debug.Log("Move " + moveInput.x * speed);
        transform.position += new Vector3(moveInput.x * speed, 0, 0);

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, Mathf.Abs(yVelocity) + .1f, groundLayerMask); //Raycasts to avoid tunneling
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

        

        if(!menuUp)
        {
            transform.position += new Vector3(0, yVelocity, 0);

            if (yVelocity > -3 && !grounded)
            {
                yVelocity -= .8f * Time.fixedDeltaTime;
            }
        }

        if (transform.position.y < -22)
        {
            Reset();
        }

    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Jump()
    {
        if(grounded)
        {
            yVelocity += .4f;
        }
    }
}
