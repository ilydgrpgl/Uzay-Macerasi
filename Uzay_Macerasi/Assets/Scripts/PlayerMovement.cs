using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    Vector2 velocity;
    [SerializeField]
    float jumpPower = default;

   
    int jumpingLimit = 2;

    int jumpingPoint;

    Joystick joystick;
    JoystickButton joystickButton;
    bool jumping;


    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystickButton=FindObjectOfType<JoystickButton>();
    }

    
    void Update()
    {
#if UNITY_EDITOR
        Keyboard_Control();
        #else
                JoystickControl();
        #endif
        // Platform Dependent Compilation

     

    }

    void Keyboard_Control()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");//sað sol yönü
        Vector2 scale=transform.localScale;
        if(moveInput>0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput*3.0f, 10.0f*Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if(moveInput<0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * 3.0f, 10.0f * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, 40.0f * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
       transform.Translate(velocity*Time.deltaTime);


        if (Input.GetKeyDown("space")) // joystickte zýplama zamanýný yakalaymadýðýmýz için almýyoruz.
        {
            JumpStart();
        }
        if(Input.GetKeyUp("space"))
        {
            JumpStop();
        }
    }
    void JoystickControl()
    {
        float moveInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * 3.0f, 10.0f * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * 3.0f, 10.0f * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, 40.0f * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if(joystickButton.keyPressed==true&& jumping==false)
        {
            jumping = true;
            JumpStart();
        }
        if (joystickButton.keyPressed == false && jumping == true)
        {
            jumping=false;
            JumpStop();
        }
    }
    void JumpStart()
    {
        if(jumpingPoint < jumpingLimit)
        {
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        
        }
       

    }
    void JumpStop()
    {
        animator.SetBool("Jump", false);
        jumpingPoint++;
    }
    public void ResetJump()
    {
        jumpingPoint = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Dead")
        {
            FindObjectOfType<GameControl>().GameEnd();
        }
    }
}
