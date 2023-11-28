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
    public float spring = 2f;
    public float damper = 0f;
    public float massscale = 2f;
    [HideInInspector] public bool isPaused = false;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPaused)       
        {
            TongueShoot(); 
        }
        else if (Input.GetMouseButtonUp(0) && !isPaused)
        {
            TongueRetract();
        }
        
    }
    private void LateUpdate()
    {
         if(!isPaused) Drawtongue();
    }


    void TongueShoot()
    {


        //Finds Direction tongue needs to be shot at
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 22.5f));
        Vector3 direction = (mousePos - player.transform.position).normalized;
        
        //checks if tongue would hit something
        if (Physics.Raycast(player.transform.position, direction, out RaycastHit hit, maxDistance))
        {
            if (hit.transform.CompareTag("Swingable") && Vector3.Distance(player.transform.position, hit.point)<10f)
            {
                grapplepoint = hit.point;
                joint = player.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplepoint;

                float distancefromgrapplepoint = Vector3.Distance(player.transform.position, grapplepoint);

                joint.maxDistance = distancefromgrapplepoint * 0.7f;
                joint.minDistance = distancefromgrapplepoint * 0.1f;

                joint.spring = spring;
                joint.damper = damper;
                joint.massScale = massscale;
            }
        }
        
    }

    public void TongueRetract()
    {
        lr.positionCount = 0;
        Destroy(joint);
        lr.positionCount = 2;
        
    }

    void Drawtongue()
    {
        if (!joint) return;
        lr.SetPosition(0, player.transform.position);
        lr.SetPosition(1, grapplepoint);
    }
    
}
