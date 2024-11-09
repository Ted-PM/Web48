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
    bool canOpen = true;

    private void Start()
    {
        curtainL.transform.position = LcurtClose.position;
        curtainR.transform.position = RcurtClose.position;

        canOpen = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            canOpen = true;
        }

        openCurtain();
    }

    void openCurtain()
    {

        if (canOpen)
        {
            if (curtainL.transform.position.x > LcurtOpen.transform.position.x)
            {
                curtainL.transform.position += new Vector3((float)-0.5, 0, 0);

            }
            if (curtainR.transform.position.x < RcurtOpen.transform.position.x)
            {
                curtainR.transform.position += new Vector3((float)0.5, 0, 0);

            }
            StartCoroutine(StartCooldown());
        }

    }

    public IEnumerator StartCooldown()
    {
        canOpen = false;

        yield return new WaitForSeconds(CooldownDuration);

        //openCurtain();

        canOpen = true;
    }
}
