using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetNpcController : MonoBehaviour
{
    TargetNpc _npc;
    [SerializeField] GameObject _player;
    public float checkSightRange;
    public List<Transform> targets = new List<Transform>();
    private Transform _currentTarget;

    private void Awake()
    {
        _npc = GetComponent<TargetNpc>();
        _player = GameManager.instance.GetPlayer.gameObject;
    }

    void Start()
    {
        checkSightRange = _npc.sightRange;
        SelectRandomTarget(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < checkSightRange)
        {
            if (_npc.IsInSight(_player.transform))
            {
                //_npc.Die(); TEST
                SelectRandomTarget(true);
            }
        }
    }

    public void SelectRandomTarget(bool lookedAtPlayer)
    {
        if (targets.Count <= 1 && lookedAtPlayer)
        {   
            _npc.Die();
            return;
        }
        
        List<Transform> availableTargets = new List<Transform>();
        
        for (int i = 0; i < targets.Count; i++)
        {
            if(_currentTarget != targets[i]) availableTargets.Add(targets[i]);
        }

        _currentTarget = availableTargets[Random.Range(0, availableTargets.Count)];
        
        _npc.LookAt(_currentTarget);
    }

    public void AddTarget(Transform transform)
    {
        
    }

    public void RemoveTarget(Transform transform)
    {
        if (targets.Contains((transform))) targets.Remove(transform);
        if (_currentTarget == transform) SelectRandomTarget(false);
    }
    
    bool InSight()
    {
        Debug.Log("Check in sight");
        if (_player == null) return false;
        return _npc.IsInSight(_player.transform);
    }

    bool IsDead()
    {
        return _npc.isDead;
    }
}
