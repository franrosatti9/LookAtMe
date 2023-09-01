using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNpcController : MonoBehaviour
{
    private WaypointNpc _npc;
    private Vector3 _dir;
    private int waypointIndex;
    [SerializeField] GameObject _player;
    [SerializeField] private Transform[] waypoints;
    public float checkSightRange;

    private void Awake()
    {
        _npc = GetComponent<WaypointNpc>();
        _player = GameManager.instance.GetPlayer.gameObject;
    }

    void Start()
    {
        waypointIndex = 0;
        checkSightRange = _npc.sightRange;
        _npc.LookAt(waypoints[waypointIndex]);
        _dir = waypoints[waypointIndex].position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < checkSightRange)
        {
            if (_npc.IsInSight(_player.transform))
            {
                _npc.Die();
            }
        }   
        
        CheckWaypoints();
        _npc.Move(_dir);
    }

    public void CheckWaypoints()
    {
        if (Vector3.Distance(waypoints[waypointIndex].transform.position, transform.position) <
            1f) //Cuando llegamos al waypoint, subimos el index para caminar hacia el próximo
        {
            waypointIndex++;
            if (waypointIndex == waypoints.Length) waypointIndex = 0; 
            _dir = waypoints[waypointIndex].position - transform.position;
            
            _npc.LookAt(waypoints[waypointIndex]);
        }
        
        
    }
}
