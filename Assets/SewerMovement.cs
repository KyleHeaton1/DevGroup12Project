using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerMovement : MonoBehaviour
{


    public bool aboveground = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Portal")))
        {
            if (aboveground == false)
            {
                transform.position = new Vector3(transform.position.x+13f, transform.position.y+68f, transform.position.z);
                aboveground = true;
            }
            else if (aboveground == true)
            {
                transform.position = new Vector3(-248.8f, -164.3f, transform.position.z);
                aboveground = false;
            }

        }
    }
}
