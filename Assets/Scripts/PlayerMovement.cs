using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_movement : MonoBehaviour
{
    public Rigidbody playerRB;
    private BoxCollider bodyCollider;
    private Vector3 _input;
    private Vector3 lastPos;
    public float speed = 12;
    public float turnSpeed = 180f;
    private Animator lAnimator;
    private bool touchingObstacle;

    void Start()
    {
        bodyCollider = GetComponent<BoxCollider>();
        playerRB = GetComponent<Rigidbody>();
        lAnimator = GetComponent<Animator>();
        if (lAnimator != null)
        {
            Debug.Log("Animator is attached");
        }
    }

    void Update()
    {
        // Handle movement input and direction changes
        SetInput();
        Direction();
    }

    void FixedUpdate()
    {
        // Move the player with Rigidbody and apply obstacle interaction logic
        MovePlayer();

        // Update walking animation state
        lAnimator.SetBool("Walking", _input.magnitude > 0f && !touchingObstacle);
        Debug.Log("Walking Bool: " + lAnimator.GetBool("Walking"));
    }

    void SetInput()
    {
        // Get player movement input
        _input = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, -Input.GetAxisRaw("Vertical"));
    }

    void Direction()
    {
        // Rotate the player towards movement direction
        if (_input != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(_input, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        }
    }

    void MovePlayer()
    {
        // If the player is touching an obstacle, move with reduced speed or prevent movement
        if (touchingObstacle)
        {
            // Optionally apply reduced movement speed when touching an obstacle
            playerRB.MovePosition(transform.position + (transform.forward * _input.normalized.magnitude) * (speed / 2) * Time.deltaTime);
        }
        else
        {
            // Regular movement if not touching obstacle
            playerRB.MovePosition(transform.position + (transform.forward * _input.normalized.magnitude) * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // When the player collides with an obstacle, stop movement
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerRB.velocity = Vector3.zero; // Stop player immediately upon collision
            touchingObstacle = true; // Mark as touching an obstacle
            Debug.Log("Touching Obstacle");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // When the player stops touching the obstacle, resume normal movement
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            touchingObstacle = false;
            Debug.Log("No longer touching obstacle");
        }
    }
}
