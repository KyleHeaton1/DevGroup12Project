using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    public bool isgrounded;
    public float jumppower;
    public float movedirection;
    public Rigidbody rb;
    public float currentjumpdirection;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //Direction frog face
        movedirection = Input.GetAxisRaw("Horizontal");
        if (movedirection > 0f)
        {
            sr.flipX = false;
        }
        else if (movedirection < 0f)
        {
            sr.flipX = true;
        }



        //Getting Jump power
        if (Input.GetKey("a") && isgrounded || Input.GetKey("d") && isgrounded)
        {
            if (jumppower < 20)
            {
                jumppower += 0.025f;
                currentjumpdirection = movedirection;
            }
        }


        //Jumping
        if(Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            if (isgrounded)
            {
                float horizontalMod = 1f;
                if (jumppower > 10)
                {
                    horizontalMod = 0.5f;
                }
                rb.velocity = (new Vector2(currentjumpdirection*jumppower*horizontalMod, jumppower));
                jumppower = 0f;
            }
            
        }


    }



    //ground detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isgrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isgrounded = false;
        }
    }
}
