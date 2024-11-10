using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_movement : MonoBehaviour
{
    public Rigidbody playerRB;
    BoxCollider bodyCollider;
    Vector3 _input;
    private Vector3 lastPos;                                                                                                      
    public float speed = 12;
    public float turnSpeed = 180f;
    private Animator lAnimator;

    void Start()
    {
        bodyCollider = GetComponent<BoxCollider>();
        playerRB = GetComponent<Rigidbody>();
        lAnimator = GetComponent<Animator>();
        if (lAnimator != null )
        {
            Debug.Log("animator is attached");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!GameManager.instance.menu.activeSelf && !ZoomOnObject.instance.start)
        //{
        if ((!ConversationManager.Instance.IsConversationActive) && !GameManager.instance.menu.activeSelf)
        {
            setInput();
            direction();
        }

        
        
        //}
    }

    void FixedUpdate()
    {
        movePlayer();
    
        
       lAnimator.SetBool("Walking", _input.magnitude != 0);
       Debug.Log("Bool is " + lAnimator.GetBool("Walking"));
    }

    void setInput()
    {
        _input = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, -Input.GetAxisRaw("Vertical"));
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