using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System;
using JetBrains.Annotations;
using System.Linq;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText1;
    public Text player;
    public Text countText;
    private int count; 
    private Rigidbody rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        
        countText1.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        string palindrome = other.GetComponentInChildren<TextMesh>().text;
        bool check = CheckPal(palindrome);
        if (check.Equals(true) && other.gameObject.CompareTag("Pick Up"))
        {        
            other.gameObject.SetActive(false);
            count = count + 1;
            player.text = "Count of Palindrome: " + count.ToString();
            SetCountText();
            
        }
    }
    public bool CheckPal(string pal)
    {
        char[] ab = pal.ToCharArray();
        Array.Reverse(ab);
        string reverse = new string(ab);
        bool p = pal.Equals(reverse, StringComparison.OrdinalIgnoreCase);
        if (p == true)
        {

            return true;
        }
        return false;
    }

    void SetCountText()
    {
        countText.text = "Total Palindrome: " + count.ToString();

        if (count >= 3)
        {

            countText1.text = "Maximum Collected Palindromes Successfully are:" + count;

        }

    }
   

    
}
