using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [SerializeField] TargetNpcController lookingNpc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopTargeting()
    {
        if (lookingNpc.targets.Contains(this.transform))
        {
            lookingNpc.RemoveTarget(this.transform);
        }
    }
    
    public void StopTargeting(Transform newTarget)
    {
        if (lookingNpc.targets.Contains(this.transform))
        {
            lookingNpc.RemoveTarget(this.transform);
        }
        
        lookingNpc.AddTarget(newTarget);
    }

    /*private void OnDisable()
    {
        if (lookingNpc.targets.Contains(this.transform))
        {
            lookingNpc.RemoveTarget(this.transform);
        }
    }*/
}
