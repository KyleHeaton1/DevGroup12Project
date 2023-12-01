using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (player.transform.position.x >= -184f)
       {
            this.transform.position = new Vector3(-184f, player.transform.position.y, -19.33f);
        }
        else if (player.transform.position.x <= -311.6f)
        {
            this.transform.position = new Vector3(-311.6f, player.transform.position.y, -19.33f);
        }
    }
}
