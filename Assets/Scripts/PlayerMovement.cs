using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_movement : MonoBehaviour
{
    public Rigidbody playerRB;
    BoxCollider bodyCollider;
    Vector3 _input;
    private CharacterController _characterController;

    //public float friction; //Speed is multiplied by this value every frame after you stop holding a direction, if you are grounded.                               Recommended value: 0.5
    //public float speedCap; //Highest possible run speed.                                                                                                          Recommended value: 20
    public float speed = 12;
    public float turnSpeed = 180f;
    //public float airFriction; //Speed is multiplied by this value every frame after you stop holding a direction, if you are aerial.                              Recommended value: 
    //public float airResistanceLimit; //Air friction wil
    //[SerializeField] private bool _grounded;
    //[SerializeField] private float _horizontalInput;
    //[SerializeField] private float _verticalInput;
    void Start()
    {
        bodyCollider = GetComponent<BoxCollider>();
        playerRB = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.menu.activeSelf && !ZoomOnObject.instance.start)
        {
            setInput();
            direction();
        }
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    void setInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void direction()
    {
        if (_input != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(_input, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed);
        }

    }

    void movePlayer()
    {
        playerRB.MovePosition((transform.position + (transform.forward * _input.normalized.magnitude) * speed * Time.deltaTime));
    }
}