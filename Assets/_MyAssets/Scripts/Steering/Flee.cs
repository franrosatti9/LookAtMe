using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : ISteering
{
    Transform _self;
    Transform _target;
    public Flee(Transform self, Transform target)
    {
        _self = self;
        _target = target;
    }
    public Vector3 GetDir()
    {
        //A: Self
        //B: Target
        //A-B:  Self - Target 

        Vector3 dir = _self.position - _target.position;
        dir = dir.normalized;
        return dir;
    }
    public Transform SetSelf
    {
        set
        {
            _self = value;
        }
    }
    public Transform SetTarget
    {
        set
        {
            _target = value;
        }
    }
}