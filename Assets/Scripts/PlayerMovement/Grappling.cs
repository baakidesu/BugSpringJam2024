using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public float maxDistance ;
    private SpringJoint joint;
    private bool isGrappling;

    [Header("Technical")]
    public LayerMask whatIsGrapple;
    public Transform gunTip, camera, player;

    [Header("Joint Values")] 
    public float spring;
    public float damper; 
    public float massScale;

    [Header("Grappling Movement")]
    public float grappleSpeed = 10f; // Speed of grappling movement

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartGrapple();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            StopGrapple();
        }

        if (isGrappling)
        {
            MoveTowardsGrapplePoint();
        }
    }

    private void StopGrapple()
    {
        Debug.Log("B");
        lr.positionCount = 0;
        Destroy(joint);
        isGrappling = false;
    }

    private void StartGrapple()
    {
        Debug.Log("a");
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrapple))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(camera.position, grapplePoint);
            
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;
            
            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;

            lr.positionCount = 2;
            isGrappling = true;
        }
    }

    private void MoveTowardsGrapplePoint()
    {
        Vector3 directionToGrapplePoint = (grapplePoint - player.position).normalized;
        player.position = Vector3.MoveTowards(player.position, grapplePoint, grappleSpeed * Time.deltaTime);

        // Optionally, you can apply force for a more physics-based approach:
        // player.GetComponent<Rigidbody>().AddForce(directionToGrapplePoint * grappleSpeed, ForceMode.Acceleration);
    }

    private void DrawRope()
    {
        if (!joint)
        {
            return;
        }
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }
}
