using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    [SerializeField] private GameObject[] platormsTL;
    [SerializeField] private GameObject[] platormsTR;
    [SerializeField] private GameObject[] platormsBL;
    [SerializeField] private GameObject[] platormsBR;
    [SerializeField] private GameObject shadow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float HorizontalCheck(Vector3 checkTR, Vector3 checkTL, Vector3 checkBL, Vector3 checkBR, Vector3 moveVelocity)
    {

        if(moveVelocity.x == 0)
        {
            return moveVelocity.x;
        }

        Vector3 newTR = checkTR + moveVelocity;
        Vector3 newTL = checkTL + moveVelocity;
        Vector3 newBR = checkBR + moveVelocity;
        Vector3 newBL = checkBL + moveVelocity;

        if(moveVelocity.x < 0)
        {
            //Uses TL and TR platforms and moving left
            if (newTL.y >= 0)
            {
                if (newTL.x >= 0) //TR and moving left
                {
                    for (int i = 0; i < platormsTR.Length; i++)
                    {
                        if (newTL.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                            newTL.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2)) - checkTL.x;
                            }
                        }
                        else if (newBL.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2)) - checkBL.x;
                            }
                        }
                    }
                }
                else //TL and moving left
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newTL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                            newTL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2)) - checkTL.x;
                            }
                        }
                        else if (newBL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2)) - checkBL.x;
                            }
                        }
                    }
                }
            }
            else //BL and BR platforms and moving left
            {
                if (newBR.x >= 0) //BR and moving left
                {
                    for (int i = 0; i < platormsBR.Length; i++)
                    {
                        if (newTL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                            newTL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2)) - checkTL.x;
                            }
                        }
                        else if (newBL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2)) - checkBL.x;
                            }
                        }
                    }
                }
                else //BL and moving left
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newTL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                            newTL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2)) - checkTL.x;
                            }
                        }
                        else if (newBL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
                            {
                                return (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2)) - checkBL.x;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            //Uses TL and TR platforms and moving right
            if (newTR.y >= 0)
            {
                if (newTR.x >= 0) //TR and moving right
                {
                    for (int i = 0; i < platormsTR.Length; i++)
                    {
                        if (newTR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                            newTR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                                newTR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) - checkTR.x;
                            }
                        }
                        else if (newBR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                                newBR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) - checkBR.x;
                            }
                        }
                    }
                }
                else //TL and moving right
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newTR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                            newTR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                                newTR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) - checkTR.x;
                            }
                        }
                        else if (newBR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                                newBR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) - checkBR.x;
                            }
                        }
                    }
                }
            }
            else //BL and BR platforms and moving right
            {
                if (newBR.x >= 0) //BR and moving right
                {
                    for (int i = 0; i < platormsBR.Length; i++)
                    {
                        if (newTR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                            newTR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                            newTR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) - checkTR.x;
                            }
                        }
                        else if (newBR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                                newBR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) - checkBR.x;
                            }
                        }
                    }
                }
                else //BL and moving right
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newTR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                                newTR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                                newTR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) - checkTR.x;
                            }
                        }
                        else if (newBR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                                newBR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) - checkBR.x;
                            }
                        }
                    }
                }
            }
        }

        return moveVelocity.x;

    }

    public float VerticalCheck(Vector3 checkTR, Vector3 checkTL, Vector3 checkBL, Vector3 checkBR, Vector3 moveVelocity)
    {

        if (moveVelocity.y == 0)
        {
            return moveVelocity.y;
        }

        Vector3 newTR = checkTR + moveVelocity;
        Vector3 newTL = checkTL + moveVelocity;
        Vector3 newBR = checkBR + moveVelocity;
        Vector3 newBL = checkBL + moveVelocity;

        if (moveVelocity.y < 0)
        {
            //Uses TL and TR platforms and moving down
            if (newTL.y >= 0)
            {
                if (newTL.x >= 0) //TR and moving down
                {
                    for (int i = 0; i < platormsTR.Length; i++)
                    {
                        if (newBR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                            newBR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //right of check is in x range
                        {
                            if (newBR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2)) - checkBR.y;
                            }
                        }
                        else if (newBL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //left of check is in x range
                        {
                            if (newBL.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2)) - checkBL.y;
                            }
                        }
                    }
                }
                else //TL and down
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newBR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                            newBR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newBR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2)) - checkBR.y;
                            }
                        }
                        else if (newBL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2)) - checkBL.y;
                            }
                        }
                    }
                }
            }
            else //BL and BR platforms
            {
                if (newBR.x >= 0) //BR and down
                {
                    for (int i = 0; i < platormsBR.Length; i++)
                    {
                        if (newBR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                            newBR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newBR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2)) - checkBR.y;
                            }
                        }
                        else if (newBL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2)) - checkBL.y;
                            }
                        }
                    }
                }
                else //BL and down
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newBR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                            newBR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newBR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                                newBR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2)) - checkBR.y;
                            }
                        }
                        else if (newBL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                                newBL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newBL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                                newBL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //bottom of check is in y range
                            {
                                return (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2)) - checkBL.y;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            //Uses TL and TR platforms
            if (newTR.y >= 0)
            {
                if (newTR.x >= 0) //TR
                {
                    for (int i = 0; i < platormsTR.Length; i++)
                    {
                        if (newTR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                            newTR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                                newTR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) - checkTR.y;
                            }
                        }
                        else if (newTL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2) + .01f) &&
                                newTL.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) - checkTL.y;
                            }
                        }
                    }
                }
                else //TL
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newTR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                            newTR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                                newTR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) - checkTR.y;
                            }
                        }
                        else if (newTL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2) + .01f) &&
                                newTL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) - checkTL.y;
                            }
                        }
                    }
                }
            }
            else //BL and BR platforms
            {
                if (newBR.x >= 0) //BR
                {
                    for (int i = 0; i < platormsBR.Length; i++)
                    {
                        if (newTR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                            newTR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                                newTR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) - checkTR.y;
                            }
                        }
                        else if (newTL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2) + .01f) &&
                                newTL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) - checkTL.y;
                            }
                        }
                    }
                }
                else //BL
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newTR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                            newTR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                                newTR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) - checkTR.y;
                            }
                        }
                        else if (newTL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2) + .01f) &&
                                newTL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2) - .01f)) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2) + .01f) &&
                                newTL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2) - .01f)) //right side of check is within the platforms x range
                            {
                                return (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) - checkTL.y;
                            }
                        }
                    }
                }
            }
        }

        return moveVelocity.y;

    }

    public bool ShadowCollision(Vector3 checkTR, Vector3 checkTL, Vector3 checkBL, Vector3 checkBR)
    {
        if (checkTL.y > (shadow.transform.position.y - (shadow.transform.localScale.y / 2) + .01f) &&
            checkTL.y < (shadow.transform.position.y + (shadow.transform.localScale.y / 2) - .01f)) //top of check is within the shadows y range
        {
            if (checkTL.x > (shadow.transform.position.x - (shadow.transform.localScale.x / 2) + .01f) &&
                checkTL.x < (shadow.transform.position.x + (shadow.transform.localScale.x / 2) - .01f)) //left side of check is within the shadows x range
            {
                return true;
            }else if (checkTR.x > (shadow.transform.position.x - (shadow.transform.localScale.x / 2) + .01f) &&
                    checkTR.x < (shadow.transform.position.x + (shadow.transform.localScale.x / 2) - .01f)) //right side of check is within the shadows x range
            {
                return true;
            }
        }
        else if (checkBL.y > (shadow.transform.position.y - (shadow.transform.localScale.y / 2) + .01f) &&
                checkBL.y < (shadow.transform.position.y + (shadow.transform.localScale.y / 2) - .01f)) //bottom of check is within the platforms y range
        {
            if (checkBL.x > (shadow.transform.position.x - (shadow.transform.localScale.x / 2) + .01f) &&
                checkBL.x < (shadow.transform.position.x + (shadow.transform.localScale.x / 2) - .01f)) //left side of check is within the platforms x range
            {
                return true;
            }
            else if (checkBR.x > (shadow.transform.position.x - (shadow.transform.localScale.x / 2) + .01f) &&
                   checkBR.x < (shadow.transform.position.x + (shadow.transform.localScale.x / 2) - .01f)) //right side of check is within the shadows x range
            {
                return true;
            }
        }

        return false;
    }
}
