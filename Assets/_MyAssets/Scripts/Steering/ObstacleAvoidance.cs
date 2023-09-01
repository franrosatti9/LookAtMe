using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : ISteering
{
    Transform _self;
    Transform _target;
    float _radius;
    float _multiplier;
    Collider[] _objs;
    LayerMask _mask;

    public ObstacleAvoidance(Transform self, Transform target, float radius, int maxObjs, float multiplier, LayerMask mask)
    {
        _self = self;
        _target = target;
        _radius = radius;
        _objs = new Collider[maxObjs];
        _mask = mask;
        _multiplier = multiplier;
    }
    public ObstacleAvoidance(Transform self, float radius, int maxObjs, float multiplier, LayerMask mask)
    {
        _self = self;
        _radius = radius;
        _objs = new Collider[maxObjs];
        _mask = mask;
        _multiplier = multiplier;
    }
    public Vector3 GetDir()
    {
        if (_target) return Vector3.zero;
        Vector3 dir = (_target.position - _self.position).normalized;
        return GetDir(dir);
    }
    public Vector3 GetDir(Vector3 dir)
    {
        int countObjs = Physics.OverlapSphereNonAlloc(_self.position, _radius, _objs, _mask);
        Collider nearObj = null;
        float distanceNearObj = 0;
        for (int i = 0; i < countObjs; i++)
        {
            var curr = _objs[i];
            if (_self.position == curr.transform.position) continue;
            Vector3 nearPoint = curr.ClosestPointOnBounds(_self.position);
            float distanceCurr = Vector3.Distance(_self.position, nearPoint);
            if (nearObj == null)
            {
                nearObj = curr;
                distanceNearObj = distanceCurr;
            }
            else
            {
                if (distanceNearObj > distanceCurr)
                {
                    nearObj = curr;
                    distanceNearObj = distanceCurr;
                }
            }
        }

        if (nearObj != null)
        {
            var posObj = nearObj.transform.position;
            Vector3 dirObstacleToSelf = (_self.position - posObj);
            dirObstacleToSelf = dirObstacleToSelf.normalized * ((_radius - distanceNearObj) / _radius) * _multiplier;
            dir += dirObstacleToSelf;
            dir = dir.normalized;
        }
        return dir;
    }
}
