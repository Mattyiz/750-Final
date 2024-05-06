using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float speed = .15f;
    [SerializeField] private float cooldownTime = .5f;
    [SerializeField] private bool finalLevel;
    [SerializeField] private int aiPhase = 0;
    private Vector3 targetPoint;
    private int direction;


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

        //aiPhase = 0;
        targetPoint = transform.position;
        direction = -1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowCollision();

        if (!playerMovement.menuUp)
        {

            if(finalLevel)
            {
                FinalAI();
                return;
            }

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

    public void FinalAI()
    {

        if(aiPhase <= 0)
        {
            aiPhase = Random.Range(1, 5);
        }

        Vector3 distance;

        switch (aiPhase)
        {

            case 1:
                //Normal behavior
                positionCooldown -= Time.fixedDeltaTime;
                if (positionCooldown <= 0)
                {
                    oldPlayerPosition = playerPosition;
                    playerPosition = player.transform.position;
                    positionCooldown = cooldownTime;
                }

                distance = oldPlayerPosition - transform.position;

                distance.Normalize();
                distance = distance * speed;
                transform.position += distance;
                break;
            case 2:
                //Go to random position relatively near the player, adds some general chaos
                positionCooldown -= Time.fixedDeltaTime;
                if (positionCooldown <= 0)
                {
                    oldPlayerPosition = playerPosition;
                    playerPosition = player.transform.position;
                    positionCooldown = cooldownTime;
                }

                if ((targetPoint.x + speed >= transform.position.x && targetPoint.y + speed >= transform.position.y) ||
                    (targetPoint.x - speed <= transform.position.x && targetPoint.y - speed <= transform.position.y))
                {
                    targetPoint = new Vector3(Random.Range(oldPlayerPosition.x - 10f, oldPlayerPosition.x + 10f), Random.Range(oldPlayerPosition.y - 5f, oldPlayerPosition.y + 5f), 0);
                }

                distance = targetPoint - transform.position;

                distance.Normalize();
                distance = distance * (speed * 1.5f);
                transform.position += distance;
                break;
            case 3:
                //Goes from one side of the screen to the other before changing y direction. Inspired by the Centipede in the Atari game Centipede. Just tries to add chaos
                if (targetPoint == transform.position)
                {
                    targetPoint = new Vector3(40, transform.position.y, 0);
                }

                if (transform.position.x >= 35 || transform.position.x <= -35)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y * direction), 0);
                    targetPoint = new Vector3(targetPoint.x * -1, transform.position.y, 0);

                    if(transform.position.y >= 19 || transform.position.y <= -15)
                    {
                        direction = direction * -1;
                    }
                }

                distance = targetPoint - transform.position;

                distance.Normalize();
                distance = distance * (speed * 2.5f); //This guy generally doesn't do anything so I'm speeding him up
                transform.position += distance;

                break;
            case 4:
                //This gets between the player and 0,0. It doesn't try to be the kill but it tries to set up the kill

                positionCooldown -= Time.fixedDeltaTime;
                if (positionCooldown <= 0)
                {
                    oldPlayerPosition = playerPosition;
                    playerPosition = player.transform.position;
                    positionCooldown = cooldownTime;
                }

                if (oldPlayerPosition.x <= 0)
                {
                    targetPoint = new Vector3(oldPlayerPosition.x + 2, 0, 0);
                }
                else
                {
                    targetPoint = new Vector3(oldPlayerPosition.x - 2, 0, 0);
                }

                if (oldPlayerPosition.y <= 0)
                {
                    targetPoint = new Vector3(targetPoint.x, oldPlayerPosition.y + 2, 0);
                }
                else
                {
                    targetPoint = new Vector3(targetPoint.x, oldPlayerPosition.y - 2, 0);
                }

                distance = targetPoint - transform.position;

                distance.Normalize();
                distance = distance * speed;
                transform.position += distance;


                break;
            default:
                aiPhase = 0;
                break;
        }

    }

}
