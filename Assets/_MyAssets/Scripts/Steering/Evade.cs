using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : ISteering
{
    Transform _self;
    Transform _target;
    IVel _vel;
    float _timePrediction;
    float _offset;
    public Evade(Transform self, Transform target, IVel vel, float timePrediction, float offset = 2)
    {
        _self = self;
        _target = target;
        _vel = vel;
        _timePrediction = timePrediction;
        _offset = offset;
    }
    public Vector3 GetDir()
    {
        float multiplierDirection = (_vel.Vel * _timePrediction);
        float distance = Vector3.Distance(_target.position, _self.position);

        if (multiplierDirection >= distance)
        {
            multiplierDirection = distance / _offset;
        }
        Vector3 finitPos = _target.position + _target.forward * multiplierDirection;
        //A-B = B-->A
        Vector3 dir = _self.position - finitPos;
        dir = dir.normalized;
        return dir;
    }
}
