using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    [SerializeField] private GameObject[] platormsTL;
    [SerializeField] private GameObject[] platormsTR;
    [SerializeField] private GameObject[] platormsBL;
    [SerializeField] private GameObject[] platormsBR;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HorizontalCheck(Vector3 checkTR, Vector3 checkTL, Vector3 checkBL, Vector3 checkBR, Vector3 moveVelocity)
    {

        Vector3 newTR = checkTR + moveVelocity;
        Vector3 newTL = checkTL + moveVelocity;
        Vector3 newBR = checkBR + moveVelocity;
        Vector3 newBL = checkBL + moveVelocity;

        if(moveVelocity.x < 0)
        {
            //Uses TL and TR platforms
            if (newTL.y >= 0)
            {
                if (newTL.x >= 0) //TR
                {
                    for (int i = 0; i < platormsTR.Length; i++)
                    {
                        if (newTL.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) &&
                            newTL.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //TL
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newTL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                            newTL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
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
                        if (newTL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                            newTL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //BL
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newTL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                            newTL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
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
                        if (newTR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) &&
                            newTR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                                newTR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                                newBR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //TL
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newTR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                            newTR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                                newTR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                                newBR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
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
                        if (newTR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                            newTR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                            newTR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                                newBR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //BL
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newTR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                                newTR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                                newTR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                                newBR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }

        return false;

    }

    public bool VerticalCheck(Vector3 checkTR, Vector3 checkTL, Vector3 checkBL, Vector3 checkBR, Vector3 moveVelocity)
    {

        Vector3 newTR = checkTR + moveVelocity;
        Vector3 newTL = checkTL + moveVelocity;
        Vector3 newBR = checkBR + moveVelocity;
        Vector3 newBL = checkBL + moveVelocity;

        if (moveVelocity.y < 0)
        {
            //Uses TL and TR platforms
            if (newTL.y >= 0)
            {
                if (newTL.x >= 0) //TR
                {
                    for (int i = 0; i < platormsTR.Length; i++)
                    {
                        if (newBR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                            newBR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newBR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.y > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //TL
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newBR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                            newBR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newBR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
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
                        if (newBR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                            newBR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newBR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //BL
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newBR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                            newBR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newBR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                                newBR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newBL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                                newBL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newBL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                                newBL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
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
                        if (newTR.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                            newTR.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) &&
                                newTR.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newTL.x > (platormsTR[i].transform.position.x - (platormsTR[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsTR[i].transform.position.x + (platormsTR[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsTR[i].transform.position.y - (platormsTR[i].transform.localScale.y / 2)) &&
                                newTL.y < (platormsTR[i].transform.position.y + (platormsTR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //TL
                {
                    for (int i = 0; i < platormsTL.Length; i++)
                    {
                        if (newTR.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                            newTR.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                                newTR.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newTL.x > (platormsTL[i].transform.position.x - (platormsTL[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsTL[i].transform.position.x + (platormsTL[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsTL[i].transform.position.y - (platormsTL[i].transform.localScale.y / 2)) &&
                                newTL.y < (platormsTL[i].transform.position.y + (platormsTL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
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
                        if (newTR.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                            newTR.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                                newTR.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newTL.x > (platormsBR[i].transform.position.x - (platormsBR[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsBR[i].transform.position.x + (platormsBR[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsBR[i].transform.position.y - (platormsBR[i].transform.localScale.y / 2)) &&
                                newTL.y < (platormsBR[i].transform.position.y + (platormsBR[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
                else //BL
                {
                    for (int i = 0; i < platormsBL.Length; i++)
                    {
                        if (newTR.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                            newTR.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //top of check is within the platforms y range
                        {
                            if (newTR.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                                newTR.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                        else if (newTL.x > (platormsBL[i].transform.position.x - (platormsBL[i].transform.localScale.x / 2)) &&
                                newTL.x < (platormsBL[i].transform.position.x + (platormsBL[i].transform.localScale.x / 2))) //bottom of check is within the platforms y range
                        {
                            if (newTL.y > (platormsBL[i].transform.position.y - (platormsBL[i].transform.localScale.y / 2)) &&
                                newTL.y < (platormsBL[i].transform.position.y + (platormsBL[i].transform.localScale.y / 2))) //right side of check is within the platforms x range
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }

        return false;

    }
}
