using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 grapplePoint;
    [SerializeField] LayerMask whatIsGrappleable;
    [SerializeField] Transform gunTip, dogCamera, player;

    SpringJoint joint;

    [Header("Grapple Parameter")]
    [SerializeField] float maxDistance = 100f;
    [SerializeField] float jointSpring;
    [SerializeField] float jointDamper;
    [SerializeField] float jointMassScale;

    AudioSource grappleAudio;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        grappleAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartGrapple();

        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void StartGrapple()
    {
        RaycastHit hit;
        lineRenderer.positionCount = 2;
        if (Physics.Raycast(dogCamera.position,dogCamera.forward,out hit, maxDistance,whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = jointSpring;
            joint.damper = jointDamper;
            joint.massScale = jointMassScale;

            Debug.Log("grapple");
            grappleAudio.Play();
        }
    }

    private void StopGrapple()
    {
        lineRenderer.positionCount = 0;
        Destroy(joint);
        Debug.Log("stop grapple");
    }

    void DrawRope()
    {
        if (!joint) return;

        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
