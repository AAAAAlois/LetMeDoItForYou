using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDog : MonoBehaviour
{
    public Grappling grappling;

    private Quaternion desiredRotation;
    private float rotationSpeed = 5f;

    [SerializeField] Transform camTrans;

    void Update()
    {
        if (!grappling.IsGrappling())
        {
            desiredRotation = transform.parent.rotation * Quaternion.Euler(0,90,0);
            //transform.forward = Vector3.Lerp(transform.forward, transform.parent.forward, Time.deltaTime * 10.0f);
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(grappling.GetGrapplePoint() - transform.position);
            //transform.forward = Vector3.Lerp(transform.forward, camTrans.right, Time.deltaTime * 10.0f);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
