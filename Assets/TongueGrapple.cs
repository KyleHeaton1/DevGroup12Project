using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueGrapple : MonoBehaviour
{
    public GameObject player;
    private Vector3 mousePos;
    public Camera Camera;
    private float maxDistance = 100f;
    private SpringJoint joint;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TongueShoot();
        }
    }


    void TongueShoot()
    {
        RaycastHit hit;

        mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = (mousePos - transform.position).normalized;

        if (Physics.Raycast(player.transform.position, direction, out hit, maxDistance))
        {

        }
    }
}
