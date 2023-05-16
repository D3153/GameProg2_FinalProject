using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public bool hasPowerUp = false;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    // private Animator animator;
    // public ParticleSystem fx;
    private float walkSpeed = 5;
    private float runSpeed = 8; 
    public float numOfJumps = 0f;

    Rigidbody rb;
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
        // animator = GetComponent<Animator>();
        // fx = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
       ProcessMovement();
    }

    // void DisableRootMotion()
    // {
    //     animator.applyRootMotion = false;  
    // }

    // void UpdateAnimator()
    // {     
    //     // Movement
    //     if (Mathf.Abs(Input.GetAxis("Horizontal"))>0.0f || Mathf.Abs(Input.GetAxis("Vertical"))>0.0f)
    //     {
    //         if (Input.GetButton("Fire3"))// Left shift
    //         {
    //             animator.SetFloat("CharSpeed",1.0f);
    //         }
    //         else
    //         {
    //             animator.SetFloat("CharSpeed",0.5f);
    //         }
    //     }
    //     else 
    //     {
    //         animator.SetFloat("CharSpeed",0.0f);

    //     }
        
    //     // Is Grounded
    //     animator.SetBool("IsGrounded",groundedPlayer);
        
    // }

    void ProcessMovement()
    { 
        // Moving the character foward according to the speed
        float speed = 8;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Turning the character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        // Making sure we dont have a Y velocity if we are grounded
        // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && Input.GetButtonDown("Jump") && numOfJumps == 0f)
        {
            gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            numOfJumps += 1;
        }
        else if (!groundedPlayer && Input.GetButtonDown("Jump") && numOfJumps == 1f && hasPowerUp)
        {
            gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            numOfJumps += 1;
            // fx.Play();
            // animator.SetBool("IsJumping",true);
            // animator.SetFloat("TimesJumped", numOfJumps);
            hasPowerUp = false;
        }
        else if (groundedPlayer)
        {
            // Dont apply gravity if grounded and not jumping
            gravity.y = -1.0f;
            numOfJumps = 0;
            // animator.SetBool("IsJumping",false);
            // animator.SetFloat("TimesJumped", numOfJumps);
        }
        else 
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }  

        playerVelocity = gravity * Time.deltaTime + move * Time.deltaTime * speed;
        controller.Move(playerVelocity);
    }
}
