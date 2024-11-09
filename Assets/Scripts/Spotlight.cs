using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spotlight : MonoBehaviour
{
    public GameObject thingToPointTo;       // character usually
    Transform pointToPosition;              // where character is rn

    void Start()
    {
        pointToPosition = thingToPointTo.GetComponent<Transform>().transform;
    }

    void Update()
    {
        transform.LookAt(pointToPosition);

    }
}
