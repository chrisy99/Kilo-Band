using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Game Objects
    Camera cam;
    public CharacterController controller;

    // Physics variables
    const float gravity = -9.8f;
    public float moveSpeed = 12f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask ground;


    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update

    // logic component of player generate sound 
    public float interaction_radius = 3f;
    void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MoveVertical();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // sets interaction radius(volume) based on movement speed
        if ((x == 0) && (z == 0))
        {
            interaction_radius = 0f;
        }
        else
        {
            interaction_radius = 4f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 25f;
                interaction_radius = 8f;
            }
            else
            {
                moveSpeed = 12f;
            }
        }
        // TODO: Add volume controls

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void MoveVertical()
    {
        // TLDR : grounded check, to stop building fall velocity when true
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(3f * -2f * gravity);
        }

        // gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    // Draw our radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interaction_radius);
    }
}
