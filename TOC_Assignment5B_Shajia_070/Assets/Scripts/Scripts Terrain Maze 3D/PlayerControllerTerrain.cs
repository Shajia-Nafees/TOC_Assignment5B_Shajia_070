using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTerrain : MonoBehaviour
{
    //movement speed in units per second
    public float speed;
    private Rigidbody rb;
    public AudioSource sound;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        string getText = other.gameObject.GetComponent<CText>().nameLable.text.ToString();
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (IsBalanced(getText) == true)
            {
                other.gameObject.SetActive(false);
                sound.Play();
                count++;
                SetCountText();
            }

        }
    }
    void SetCountText()
    {
        countText.text = "Matching Parenthesis: " + count.ToString();

        if (count == 21)
        {
            winText.text = "Player Collects All the Matching Parenthesis";
        }
       

    }

    static public bool IsBalanced(string getText)
    {

        const char L_Parenthesis = '(';
        const char R_Parenthesis = ')';
        uint Count = 0;

        try
        {
            checked  // Turns on overflow checking.
            {
                for (int Index = 0; Index < getText.Length; Index++)
                {
                    switch (getText[Index])
                    {
                        case L_Parenthesis:
                            Count++;
                            continue;
                        case R_Parenthesis:
                            Count--;
                            continue;
                        default:
                            continue;
                    }  // end of switch()

                }
            }
        }

        catch (OverflowException)
        {
            return false;
        }
        if (Count == 0)
        {
            return true;
        }
        return false;
    }
}