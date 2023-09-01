using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EventNpc : BaseNpc
{
    public string eventAnimationTrigger;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    public override void LookAt(Transform target)
    {
        //anim.SetTrigger(eventAnimationTrigger);
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    public void OnCompleteEvent()
    {
        anim.SetTrigger(eventAnimationTrigger);
    }
}
