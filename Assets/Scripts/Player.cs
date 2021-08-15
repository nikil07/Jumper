using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Joystick joystick;
    Animator animator;

    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D feetCollider;
    float gravityScaleAtStart;
    

    bool isAlive = true;
    bool isMoving = false;

    PlayerState playerState = PlayerState.IDLE;

    private enum PlayerState {RUN, JUMP, IDLE};

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        gravityScaleAtStart = myRigidBody.gravityScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isAlive)
          //  return;
        run();
        flipSprite();
        //jump();
        //climb();
        //die();
        animator.SetFloat("JumpSpeedMultiplier", Time.deltaTime);
    }

    private void die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            animator.SetBool("isAlive", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(20f, 20f);
        }
    }

    private void climb()
    {

        /*if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidBody.gravityScale = 0;
            float yMovement = CrossPlatformInputManager.GetAxis("Vertical");
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, yMovement * climbSpeed);

            bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            if (playerHasVerticalSpeed)
            {
                animator.SetBool("isClimbing", true);
            }
            else
            {
                animator.SetBool("isClimbing", false);
            }
        }
        else
        {
            myRigidBody.gravityScale = gravityScaleAtStart;
            animator.SetBool("isClimbing", false);
        }*/
    }

    public void jump()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
                    myRigidBody.velocity += new Vector2(0, jumpSpeed);
        }
        else {
            playerState = PlayerState.JUMP;
        }
    }

    private void run()
    {
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        myRigidBody.velocity = new Vector2(joystick.Horizontal * movementSpeed, myRigidBody.velocity.y);

    }

    private void flipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerState != PlayerState.JUMP && playerHasHorizontalSpeed)
        {
            playerState = PlayerState.RUN;
            animator.SetBool("Run", true);
            transform.localRotation = Quaternion.Euler(0, Mathf.Sign(myRigidBody.velocity.x) * 60, 0);
        }
        else
        {
            animator.SetBool("Run", false);
            playerState = PlayerState.IDLE;
        }
    }

    public void disableControls()
    {
        isAlive = false;
    }
}