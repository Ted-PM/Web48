using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtains : MonoBehaviour
{
    public Transform LcurtClose;
    public Transform LcurtOpen;
    public GameObject curtainL;

    public Transform RcurtClose;
    public Transform RcurtOpen;
    public GameObject curtainR;

    public float CooldownDuration = 1f;
    public float curtainSpeed = 2f; // Speed of curtain movement (higher = faster)

    private bool canOpen = false;
    private bool canClose = false;

    private void Start()
    {
        // Initially set curtains to the closed position
        curtainL.transform.position = LcurtClose.position;
        curtainR.transform.position = RcurtClose.position;
    }

    private void Update()
    {
        // Check if C is pressed to toggle curtain open/close
        if (Input.GetKeyDown(KeyCode.C))
        {
            // If curtains are closed, start opening
            if (IsCurtainClosed())
            {
                canClose = false;
                canOpen = true;
                Debug.Log("Start opening curtains");
            }
            // If curtains are open, start closing
            else if (IsCurtainOpen())
            {
                canOpen = false;
                canClose = true;
                Debug.Log("Start closing curtains");
            }
        }

        // Handle opening and closing curtains
        if (canOpen) OpenCurtain();
        if (canClose) CloseCurtains();
    }

    // Checks if curtains are at the closed position
    bool IsCurtainClosed()
    {
        return Mathf.Approximately(curtainL.transform.position.x, LcurtClose.position.x) &&
               Mathf.Approximately(curtainR.transform.position.x, RcurtClose.position.x);
    }

    // Checks if curtains are at the open position
    bool IsCurtainOpen()
    {
        return Mathf.Approximately(curtainL.transform.position.x, LcurtOpen.position.x) &&
               Mathf.Approximately(curtainR.transform.position.x, RcurtOpen.position.x);
    }

    // Smoothly open the curtains
    void OpenCurtain()
    {
        // Move curtainL towards LcurtOpen
        if (curtainL.transform.position.x < LcurtOpen.position.x)
        {
            curtainL.transform.position += new Vector3(curtainSpeed * Time.deltaTime, 0, 0);
        }
        // Move curtainR towards RcurtOpen
        if (curtainR.transform.position.x > RcurtOpen.position.x)
        {
            curtainR.transform.position -= new Vector3(curtainSpeed * Time.deltaTime, 0, 0);
        }

        // Once both curtains are fully open, start cooldown
        if (IsCurtainOpen())
        {
            canOpen = false;
            StartCoroutine(StartCooldown());
        }
    }

    // Smoothly close the curtains
    void CloseCurtains()
    {
        // Move curtainL towards LcurtClose
        if (curtainL.transform.position.x > LcurtClose.position.x)
        {
            curtainL.transform.position -= new Vector3(curtainSpeed * Time.deltaTime, 0, 0);
        }
        // Move curtainR towards RcurtClose
        if (curtainR.transform.position.x < RcurtClose.position.x)
        {
            curtainR.transform.position += new Vector3(curtainSpeed * Time.deltaTime, 0, 0);
        }

        // Once both curtains are fully closed, start cooldown
        if (IsCurtainClosed())
        {
            canClose = false;
            StartCoroutine(StartCooldown());
        }
    }

    // Cooldown after opening curtains
    public IEnumerator StartCooldown()
    {
        // Wait for the cooldown period
        yield return new WaitForSeconds(CooldownDuration);
        canOpen = true; // Allow next operation
    }

    // Cooldown after closing curtains
    public IEnumerator StartCooldownClose()
    {
        // Wait for the cooldown period
        yield return new WaitForSeconds(CooldownDuration);
        canClose = true; // Allow next operation
    }
}
