using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float forceX; //horizontal thrust
    Rigidbody2D PlayerRigidbody;
    public static bool isdead;
    //private Collider2D coll;
    public LayerMask groundcheck;
    int jumpCount = 1;
    bool isGround = true;
    bool jumpPress;
    private Transform playerTransform;
    void Start()
    {
        isdead = false;
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        playerTransform = PlayerRigidbody.transform;
        
    }


    void IsGroundedCheck()
    {
        if (PlayerRigidbody.IsTouchingLayers(groundcheck))
        { 
            isGround = true;
            Debug.Log("isGrounded");
        }
        else 
        {
            isGround = false;
            Debug.Log("isNotGrounded");
        }
    }
    private void Jump() 
    {
        if (isGround) 
        {
            jumpCount = 1;
            Debug.Log(jumpCount);
        }
        if (jumpPress && isGround)
        {

            //directionY = totop;
            PlayerRigidbody.AddForce(Vector2.up * 6);
            jumpPress = false;
            Debug.Log(jumpCount);
            Debug.Log("First Jump");
        }
        else if(jumpPress && jumpCount > 0 && !isGround)
        {
            jumpCount--;
            PlayerRigidbody.AddForce(Vector2.up * 6);
            Debug.Log(jumpCount);
            Debug.Log("Second Jump");
            jumpPress = false;
        }
        
    }
    private void FixedUpdate()
    {
        IsGroundedCheck();
        Jump();
        
        //Debug.Log(jumpCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerRigidbody.AddForce(Vector2.right * 10);
            Debug.Log("Right");

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerRigidbody.AddForce(Vector2.left * 10);
            Debug.Log("Left");

        }
        else if (Input.GetKey(KeyCode.UpArrow)&& jumpCount > 0)
        {
            jumpPress = true;
            this.Jump();
            Debug.Log("Up");
        }
        
        //PLAYER_OUT_OF_CAMERA();

       }
}
