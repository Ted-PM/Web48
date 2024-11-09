using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMovement : MonoBehaviour
{
    bool closed, isLeft;
    public float curtainClose, curtainOpen;
    public float movementSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            if (!closed)
                Close();
            else
                Open();
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    if (!closed)
        //    {
        //        Close();
        //    }
        //    else
        //    {
        //        Open();
        //    }
        //}
    }

    void Close()
    {
        Debug.Log("close");
        transform.localPosition = curtainClose.position;
    }
        //if (transform.position.x < curtainClose.position.x && transform.position.x > curtainOpen.position.x)
        //{
        //    transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        //}
        //else if (transform.position.x > curtainClose.position.x && transform.position.x < curtainOpen.position.x)
        //{
        //    transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        //}

    void Open()
    {
        Debug.Log("open");
        transform.localPosition = curtainOpen.position;
    }
}
