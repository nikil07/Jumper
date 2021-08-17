using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action increaseDifficulty;

    [Header("Player Movement")]
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] int speedMultiplier = 5;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [Header("Progression params")]
    [SerializeField] int movementSpeedAdder = 20;
    [SerializeField] float playerProgressDepth;
    [SerializeField] float playerProgressMultiplier;
    [SerializeField] float linearDragReductionFactor = 0.4f;
    [Header("Gameobject References")]
    [SerializeField] Joystick joystick;


    Animator animator;
    Rigidbody2D myRigidBody;
    BoxCollider2D feetCollider;
    float rigidBodyLinearDrag = 1f;
    
    PlayerState playerState = PlayerState.IDLE;

    private enum PlayerState {RUN, JUMP, IDLE};

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rigidBodyLinearDrag = myRigidBody.drag;
        StartCoroutine(startFalling());
    }

    IEnumerator startFalling() {
        yield return new WaitForSeconds(3);
        Destroy(GameObject.Find("Floor"));
    }

    // Update is called once per frame
    void Update()
    {
        run();
        flipSprite();
        checkPlayerProgress();
    }

    private void checkPlayerProgress() {
        if (transform.position.y <= playerProgressDepth) {
            playerProgressDepth *= playerProgressMultiplier;
            playerProgressMultiplier *= 2;
            updateDifficulty();
        }
    }

    private void updateDifficulty() {
        increaseDifficulty?.Invoke();
        rigidBodyLinearDrag -= linearDragReductionFactor;
        myRigidBody.drag = rigidBodyLinearDrag;
        linearDragReductionFactor /= 2;

        movementSpeed += movementSpeedAdder;
        movementSpeedAdder /= 2;

        printAllValues();
    }

    private void printAllValues() {
        print( "Game elapsed time " + Time.fixedTime  +", playerProgressDepth " + playerProgressDepth + ", playerProgressMultiplier " + playerProgressMultiplier + ", rigidBodyLinearDrag " + rigidBodyLinearDrag
            + ", linearDragReductionFactor " + linearDragReductionFactor + ", movementSpeed " + movementSpeedAdder + ", movementSpeedAdder " + movementSpeedAdder);

    }

    private void die()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
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
    }
}