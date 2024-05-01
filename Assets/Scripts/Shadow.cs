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

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform.position;
        oldPlayerPosition = playerPosition;
        positionCooldown = cooldownTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!playerMovement.menuUp)
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
    }

    public void UpdatePositionCooldown(float newCooldown)
    {
        cooldownTime = newCooldown;
    }

}
