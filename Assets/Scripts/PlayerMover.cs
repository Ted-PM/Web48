using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    private CharacterController characterController;
    //private float verticalRotation = 0;
    private float verticalVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.menu.activeSelf)
        {
            // Movement
            float moveForward = Input.GetAxis("Vertical") * moveSpeed;
            float moveSideways = Input.GetAxis("Horizontal") * moveSpeed;

            Vector3 movement = new Vector3(moveSideways, verticalVelocity, moveForward);
            movement = transform.rotation * movement;

            // Jumping
            if (characterController.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    print("jump");
                    verticalVelocity = jumpForce;
                }
            }
            else
            {
                verticalVelocity -= Time.deltaTime * 10.0f; // Apply gravity
            }

                    // this make him look direction want to move. but movement direction currently dependant on player look direction -- catch 22
            //transform.rotation = Quaternion.LookRotation(new Vector3(moveSideways, 0f, moveForward));

            characterController.Move(movement * Time.deltaTime);

        }
        else
        {
            characterController.Move(Vector3.zero);
        }
    }
}
