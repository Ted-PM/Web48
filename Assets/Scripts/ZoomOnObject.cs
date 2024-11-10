using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ZoomOnObject : MonoBehaviour
{
    public static ZoomOnObject instance;
    public bool start = false;
    bool wait = false;
    public float waitTime = 5f;
    int objectID = 0;

    Camera m_MainCamera;

    Transform camPos;
    //Transform objectPos;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        m_MainCamera = Camera.main;
        camPos = m_MainCamera.transform;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void startZoom(Vector3 passedPos, int OID)
    {
        start = true;
        objectID = OID;
        //start = true;

        //while ((Vector3.Distance(passedPos, m_MainCamera.transform.position) <= 5))
        //{
        //    //this.transform.position = new Vector3(passedPos.x, passedPos.y, passedPos.z);
        //    m_MainCamera.transform.position = passedPos;


        //    //if (wait)
        //    //{
        //    //    this.transform.position = new Vector3(passedPos.x, passedPos.y, passedPos.z);
        //    //    StartCoroutine(StartCooldown());
        //    //}

        //}
        //for (int i = 0; i < 50; i++) 
        //{
        //    m_MainCamera.transform.position = new Vector3(passedPos.x - (float)i, ;
        //}

        m_MainCamera.transform.position = passedPos -  new Vector3(3f, -3f, 12f);
        StartCoroutine(StartCooldown());


       
        
        
    }
    public IEnumerator StartCooldown()
    {
        wait = false;

        yield return new WaitForSeconds(waitTime);
        GameManager.instance.beginInteraction(objectID);
        m_MainCamera.transform.position = camPos.transform.position;

        wait = true;
    }
}
