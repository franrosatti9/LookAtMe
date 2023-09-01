using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : BaseNpc
{
    public float speed = 2;
    public float speedRot = 10;
    public float playerEscapeRange;
    void Start()
    {
        //anim = GetComponent<Animator>();
        isDead = false;
    }
    
    void Update()
    {
        
    }
    
    public void Move(Vector3 dir)
    {
        dir.y = 0;
        transform.position += dir * (Time.deltaTime * speed);
        //transform.forward = Vector3.Lerp(transform.forward, dir, speedRot * Time.deltaTime);
    }

    public void LookDir(Vector3 dir)
    {
        dir.y = 0;
        transform.forward = Vector3.Lerp(transform.forward, dir, speedRot);
    }
    

    
}
