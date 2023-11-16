using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueGrapple : MonoBehaviour
{
    public GameObject player;
    private Vector3 mousePos;
    public Camera Camera;
    private float maxDistance = 100f;
    private Vector3 grapplepoint;
    private SpringJoint joint;
    private LineRenderer lr;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            TongueShoot();
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TongueRetract();
        }
        
    }
    private void LateUpdate()
    {
        Drawtongue();
    }


    void TongueShoot()
    {


        //Finds Direction tongue needs to be shot at
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 22.5f));
        Vector3 direction = (mousePos - player.transform.position).normalized;
        
        //checks if tongue would hit something
        if (Physics.Raycast(player.transform.position, direction, out RaycastHit hit, maxDistance))
        {
            grapplepoint = hit.point;
            joint = player.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplepoint;

            float distancefromgrapplepoint = Vector3.Distance(player.transform.position, grapplepoint);

            //joint.maxDistance = distancefromgrapplepoint * 0.8f;
            //joint.minDistance = distancefromgrapplepoint * 0.1f;

            joint.spring = 5f;
            joint.damper = 0f;
            joint.massScale = 4.5f;
        }
        
    }

    void TongueRetract()
    {
        lr.positionCount = 0;
        lr.positionCount = 2;
        Destroy(joint);
    }

    void Drawtongue()
    {
        if (!joint) return;
        print("stillGoing");
        lr.SetPosition(0, player.transform.position);
        lr.SetPosition(1, grapplepoint);
    }
    
}
