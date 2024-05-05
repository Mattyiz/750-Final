using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public Controls controls;
    private Vector2 moveInput;

    private bool grounded;

    public float speed = .5f;
    private float yVelocity;

    public bool menuUp;
    public bool showCollision;
    private LineRenderer line;
    public GameObject menu;

    [SerializeField] private CollisionManager collisionManager;

    // Start is called before the first frame update
    void Awake()
    {

        controls = new Controls();

        yVelocity = 0;

        controls.Player.Menu.Enable();
        controls.Player.Menu.performed += _ => ToggleMenu();

        controls.Player.Debug.Enable();
        controls.Player.Debug.performed += _ => ToggleCollision();


        menuUp = false;
        showCollision = false;

        line = this.GetComponent<LineRenderer>();

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
        ShowCollision();
        Vector3 move = new Vector3(0, 0, 0);

        //Horizontal movement
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        move.x = moveInput.x * speed;

        //Gravity
        if(!menuUp)
        {

            if (yVelocity > -3)
            {
                yVelocity -= .8f * Time.fixedDeltaTime;
            }

            move.y = yVelocity;

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

        if (collisionManager.ShadowCollision(TR, TL, BL, BR))
        {
            Reset();
        }

        //Debug.Log("TR - " + TR + " TL - " + TL + " BR - " + BR + " BL - " + BL);

        move.x = collisionManager.HorizontalCheck(TR, TL, BR, BL, new Vector3(move.x, 0, 0));

        if(move.y == collisionManager.VerticalCheck(TR, TL, BR, BL, new Vector3(0, move.y, 0)) && move.y != 0) //There is no collision vertically
        {
            grounded = false;
        }
        else
        {
            grounded = true;
            yVelocity = 0;
        }

        move.y = collisionManager.VerticalCheck(TR, TL, BR, BL, new Vector3(0, move.y, 0));
        
        

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
        }
    }

    public void ShowCollision()
    {
        if(showCollision)
        {
            Vector3 TR = transform.position + (transform.localScale / 2);

            Vector3 TL = TR;
            TL.x -= transform.localScale.x;

            Vector3 BL = transform.position - (transform.localScale / 2);

            Vector3 BR = BL;
            BR.x += transform.localScale.x;

            this.GetComponent<SpriteRenderer>().enabled = false;

            line.enabled = true;
            line.widthMultiplier = 0.2f;
            line.positionCount = 5;

            Vector3[] points = new Vector3[5];
            points[0] = TR;
            points[1] = TL;
            points[2] = BL;
            points[3] = BR;
            points[4] = TR;

            line.SetPositions(points);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;

            line.enabled = false;
        }
        
    }

    public void ToggleCollision()
    {
        collisionManager.ToggleCollision();

        if (showCollision)
        {
            showCollision = false;
        }
        else
        {
            showCollision = true;
        }
    }
}
