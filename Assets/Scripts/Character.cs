using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Side { Left, Middle, Right };

public class Character : MonoBehaviour
{
    public Side m_Side = Side.Middle;
    float newXPos = 0f;
    [HideInInspector]
    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public float xValue;
    private CharacterController m_Char;
    private float x;
    public float speedSwipe;
    public float jumpPower;
    private float y;
    private bool isJump = false;
    private bool isRoll = false;
    private float colHeight;
    private float colYCenter;
    public GameObject rb;
    private Vector3 scaleChange, standartScale;

    void Start()
    {
        m_Char = GetComponent<CharacterController>();
        transform.position = Vector3.zero;
        colHeight = m_Char.height;
        colYCenter = m_Char.center.y;
        standartScale = new Vector3(2f, 2f, 2f);
    }

    void Update()
    {
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        if (swipeLeft)
        {
            if(m_Side == Side.Middle)
            {
                newXPos = -xValue;
                m_Side = Side.Left;
            }
            else if(m_Side == Side.Right)
            {
                newXPos = 0f;
                m_Side = Side.Middle;
            }
        }
        else if (swipeRight)
        {
            if(m_Side == Side.Middle)
            {
                newXPos = xValue;
                m_Side = Side.Right;
            }
            else if(m_Side == Side.Left)
            {
                newXPos = 0f;
                m_Side = Side.Middle;
            }
        }

        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, 0);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * speedSwipe);
        m_Char.Move(moveVector);
        Jump();
        Roll();
    }

    public void Jump()
    {
        if(m_Char.isGrounded)
        {
            if (swipeUp)
            {
                y = jumpPower;
                isJump = true;
            }
        }
        else
        {
            y -= jumpPower * 2 * Time.deltaTime;
            isJump = false;
        }
    }


    internal float rollCounter;

    public void Roll()
    {
        rollCounter -= Time.deltaTime;
        if(rollCounter <= 0f)
        {
            rollCounter = 0f;
            isRoll = false;
            m_Char.center = new Vector3(0, colYCenter, 0);
            m_Char.height = colHeight;
            rb.transform.localScale = standartScale;
        }

        if(swipeDown)
        {
            isRoll = true;
            scaleChange = new Vector3(0, 1f, 0);
            rollCounter = 0.2f;
            y -= 10f;
            m_Char.height = colHeight / 2;
            m_Char.center = new Vector3(0, colYCenter / 2, 0);
            rb.transform.localScale -= scaleChange;
        }

    }
}
