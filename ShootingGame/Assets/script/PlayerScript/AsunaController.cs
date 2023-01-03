using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsunaController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;

    public GameObject PlayerHealth;

    public float gravity = -9.81f;
    public float speed = 10f;
    public float jumpHeight = 3f;
    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;
    private bool isIdle;

    private Animator animator;

    private Vector3 moveDirection;

    public float health = 200;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        PlayerHealth.GetComponent<PlayerHealth>().SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        // Check collision
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        moveDirection = move;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            jumpVelocity();
            isGrounded = false;
        }
        if (isGrounded == false)
        {
            animation1ButtonCheck(false, false, false, false, false, true, false);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Animation controller (1 Button)
        if (move == Vector3.zero && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false && isGrounded == true) // Idling
        {
            animation1ButtonCheck(true, false, false, false, false, false, false);
            //eye.transform.position = eye.transform.position + new Vector3(0.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.S) == false && isGrounded == true) // Move Forward
        {
            animation1ButtonCheck(false, true, false, false, false, false, false);
        }
        if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.W) == false && isGrounded == true) // Move Forward
        {
            animation1ButtonCheck(false, false, true, false, false, false, false);
        }
        if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.W) == false && isGrounded == true) // Turn Left
        {
            animation1ButtonCheck(false, false, false, true, false, false, false);
        }
        if (Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.W) == false && isGrounded == true) // turn Right
        {
            animation1ButtonCheck(false, false, false, false, true, false, false);
        }
    }
    public void animation1ButtonCheck(bool IsIdle, bool IsMovingForward, bool IsMovingBackward, bool IsMovingleft, bool IsMovingRight, bool IsJumpingUp, bool IsJumpingDown)
    {
        animator.SetBool("IsIdle", IsIdle);
        animator.SetBool("IsMovingBackward", IsMovingBackward);
        animator.SetBool("IsMovingForward", IsMovingForward);
        animator.SetBool("IsMovingLeft", IsMovingleft);
        animator.SetBool("IsMovingRight", IsMovingRight);
        animator.SetBool("IsJumpingUp", IsJumpingUp);
        animator.SetBool("IsJumpingDown", IsJumpingDown);
    }
    public void jumpDown()
    {
        animation1ButtonCheck(false, false, false, false, false, false, true);
    }
    public void jumpVelocity()
    {
        velocity.y += Mathf.Sqrt(jumpHeight * (-2f) * gravity);
    }
    public void idling()
    {
        animator.SetBool("IsIdle", false);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
    public Vector3 getMoveDir()
    {
        return moveDirection;
    }
    public float gethealth()
    {
        return health;
    }
    public void takeDamage(float amout)
    {
        health -= amout;
        PlayerHealth.GetComponent<PlayerHealth>().setHeatlh(health);
    }
}
