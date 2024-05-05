using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float speed = .15f;
    [SerializeField] private float cooldownTime = .5f;


    private Vector3 playerPosition;
    private Vector3 oldPlayerPosition;
    private float positionCooldown;

    public bool showCollision;
    private LineRenderer line;

    // Start is called before the first frame update
    void Awake()
    {

        playerPosition = player.transform.position;
        oldPlayerPosition = playerPosition;
        positionCooldown = cooldownTime;

        showCollision = false;
        line = this.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowCollision();

        if (!playerMovement.menuUp)
        {
            positionCooldown -= Time.fixedDeltaTime;
            if (positionCooldown <= 0)
            {
                oldPlayerPosition = playerPosition;
                playerPosition = player.transform.position;
                positionCooldown = cooldownTime;
            }

            Vector3 distance = oldPlayerPosition - transform.position;

            //Debug.Log(distance);

            distance.Normalize();
            distance = distance * speed;
            transform.position += distance;
        }
        
    }

    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
        Save();
    }

    public void UpdatePositionCooldown(float newCooldown)
    {
        cooldownTime = newCooldown;
        Save();
    }

    public void Save()
    {
        JsonUtility.ToJson(speed);
    }

    public void ShowCollision()
    {
        if (showCollision)
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
