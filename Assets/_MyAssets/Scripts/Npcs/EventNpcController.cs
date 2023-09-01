using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventNpcController : MonoBehaviour
{
    EventNpc _npc;
    [SerializeField] GameObject _player;
    [SerializeField] private EventSO gameEvent;
    [SerializeField] private Animation _animation;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip eventCompletedAnimation;
    bool _eventCompleted = false;
    //bool _canLookAtPlayer;

    //public bool canLookAtPlayer = false;
    public float checkSightRange;
    public Transform initialTarget;


    private void OnEnable()
    {
        gameEvent.OnEventCompleted += OnEventCompletedHandler;
    }

    private void OnDisable()
    {
        gameEvent.OnEventCompleted -= OnEventCompletedHandler;
    }

    private void Awake()
    {
        _npc = GetComponent<EventNpc>();
        _player = GameManager.instance.GetPlayer.gameObject;
    }

    void Start()
    {
        checkSightRange = _npc.sightRange;
        _npc.LookAt(initialTarget);
        //_animation.AddClip(eventCompletedAnimation, eventCompletedAnimation.name); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < checkSightRange && _eventCompleted)
        {
            if (_npc.IsInSight(_player.transform))
            {
                _npc.Die();
            }
        }
    }

    public void OnEventCompletedHandler(Transform newTarget)
    {
        _eventCompleted = true;
        _npc.LookAt(newTarget);
        _npc.OnCompleteEvent();
        //_animation.Play(eventCompletedAnimation.name);

    }
    
    bool InSight()
    {
        if (_player == null) return false;
        Debug.Log("Check in sight");
        return _npc.IsInSight(_player.transform);
    }

    bool IsDead()
    {
        return _npc.isDead;
    }
}
