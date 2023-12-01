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
    public Sprite normalfrog;
    public Sprite prepfrog;
    public Sprite flyfrog;
    public bool aboveground = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Physics.Raycast(player.transform.position, (new Vector3(, out RaycastHit hit, 2))

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
            sr.sprite = prepfrog;
            if (jumppower < 10)
            {
                jumppower += 0.02f;
                currentjumpdirection = movedirection;
            }
        }


        //Jumping
        if(Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            sr.sprite = flyfrog;
            if (isgrounded)
            {
                //float horizontalMod = 1f;
                //if (jumppower > 10)
                //{
                //    horizontalMod = 0.5f;
                //}

                //rb.velocity = (new Vector2(currentjumpdirection*Mathf.Sqrt(10*jumppower), 0.15f*(jumppower*jumppower)));
                rb.velocity = (new Vector2(currentjumpdirection * jumppower, 1.5f * jumppower));
                jumppower = 0f;
            }
            
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            //sr.sprite = normalfrog;
            isgrounded = true;
        }
    }


    //ground detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            sr.sprite = normalfrog;
            isgrounded = true;
        }

    }







    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            sr.sprite = flyfrog;
            isgrounded = false;
        }
    }
}
