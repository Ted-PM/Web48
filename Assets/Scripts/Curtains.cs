using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Curtains : MonoBehaviour
{
    public Transform LcurtClose;
    public Transform LcurtOpen;

    public GameObject curtainL;

    public Transform RcurtClose;
    public Transform RcurtOpen;

    public GameObject curtainR;

    public float CooldownDuration = 1f;

    bool canOpen = false;
    bool canClose = false;

    public bool isCutscene;

    //bool opening = false;
    //bool closing = false;
    private void Start()
    {
        if (!isCutscene)
        {
            curtainL.transform.position = LcurtClose.position;
            curtainR.transform.position = RcurtClose.position;
        }
        else
        {
            curtainL.transform.position = LcurtOpen.position;
            curtainR.transform.position = RcurtOpen.position;
        }
        
        if (isCutscene)
        {
            StartCoroutine(StartCooldownClose());
        }
        //canOpen = false;
        //StartCoroutine(StartCooldown());
    }
    private void Update()
    {
        if (!isCutscene)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if ((curtainL.transform.position.x == LcurtClose.position.x) && (curtainR.transform.position.x == RcurtClose.position.x))        // aka curtains are closed
                {
                    canClose = false;
                    Debug.Log("Start open curtains");
                    canOpen = true;
                }
                else if ((curtainL.transform.position.x == LcurtOpen.position.x) && (curtainR.transform.position.x == RcurtOpen.position.x))    // aka curtains are open
                {
                    canOpen = false;
                    Debug.Log("Start close curtains");
                    canClose = true;
                }
            }

            if ((curtainL.transform.position.x == LcurtClose.position.x) && (curtainR.transform.position.x == RcurtClose.position.x))        // aka curtains are closed
            {
                canClose = false;
            }
            if ((curtainL.transform.position.x == LcurtOpen.position.x) && (curtainR.transform.position.x == RcurtOpen.position.x))    // aka curtains are open
            {
                canOpen = false;
            }
        }
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    canClose = false;
        //    canOpen = true;
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    canClose = true;
        //    canOpen = false;
        //}

        openCurtain();
        closeCurtains();
    }

    void openCurtain()
    {

        if (canOpen)
        {
            if (curtainL.transform.position.x > LcurtOpen.transform.position.x)
            {
                curtainL.transform.position += new Vector3((float)-0.5, 0, 0);
                //curtainR.transform.position += new Vector3((float)0.5, 0, 0);
            }
            else
            {
                canOpen = false;
            }
            if (curtainR.transform.position.x < RcurtOpen.transform.position.x)
            {
                curtainR.transform.position += new Vector3((float)0.5, 0, 0);

            }
            StartCoroutine(StartCooldown());
        }

    }

    void closeCurtains()
    {

        if (canClose)
        {
            if (curtainL.transform.position.x < LcurtClose.transform.position.x)
            {
                curtainL.transform.position += new Vector3((float)0.5, 0, 0);
                //curtainR.transform.position += new Vector3((float)-0.5, 0, 0);
            }
            else
            {
                canClose = false;
            }
            if (curtainR.transform.position.x > RcurtClose.transform.position.x)
            {
                curtainR.transform.position += new Vector3((float)-0.5, 0, 0);

            }
            StartCoroutine(StartCooldownClose());
        }

    }

    public IEnumerator StartCooldown()
    {
        canOpen = false;

        yield return new WaitForSeconds(CooldownDuration);

        //openCurtain();

        canOpen = true;
    }

    public IEnumerator StartCooldownClose()
    {
        canClose = false;

        yield return new WaitForSeconds(CooldownDuration);

        //openCurtain();

        canClose = true;
    }
}
