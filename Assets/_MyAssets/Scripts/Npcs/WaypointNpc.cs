using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNpc : BaseNpc
{
    [SerializeField] private float speed;
    private Rigidbody _rb;
    private int _walk = Animator.StringToHash("Walk");

    //[SerializeField] private Transform[] waypoints;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anim.SetTrigger(_walk);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 dir)
    {
        //dir.y = transform.position.y;
        dir.Normalize();
        _rb.velocity = dir * speed;
        //dir.y = transform.position.y;
        //transform.Translate(dir * speed * Time.deltaTime);
    }
}
