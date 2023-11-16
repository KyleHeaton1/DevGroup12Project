using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    public float _speed;
    public float _gap;
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time*_speed, _gap) +10, transform.position.y, transform.position.z );
    }
}
