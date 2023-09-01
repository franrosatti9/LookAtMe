using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    enum States
    {
        Idle,
        Escape,
        Dead
    }

    FSM<States> _fsm;
    ITreeNode _root;
    
    Npc _npc;
    [SerializeField] GameObject _player;
    
    public float radiusObs;
    public float multiplierObs;
    [SerializeField] LayerMask maskObs;

    private void Awake()
    {
        _npc = GetComponent<Npc>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        TreeInitialized();
        FSMInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        _fsm.OnUpdate();
    }
    
    void FSMInitialize()  //Creación del FSM con sus estados
    {
        var obs = new ObstacleAvoidance(_npc.transform, radiusObs, 5, multiplierObs, maskObs);
        var evade = new Evade(_npc.transform, _player.transform, _player.GetComponent<IVel>(), 1f);
        
        var idle = new NpcIdleState<States>(_npc, _root);
        var escape = new NpcEvadeState<States>(_npc, _player, evade, obs, _root);
        var dead = new NpcDeadState<States>(_npc);
        
        escape.AddTransition(States.Dead, dead);
        idle.AddTransition(States.Escape, escape);
        
        _fsm = new FSM<States>();
        _fsm.SetInit(idle);
    }
    
    void TreeInitialized()
    {
        //Actions
        ITreeNode idleNode = new ActionNode(TransitionToIdle);
        ITreeNode escapeNode = new ActionNode(TransitionToEscape);
        ITreeNode deadNode = new ActionNode(TransitionToDead);


        //Questions
        ITreeNode isInSight = new QuestionNode(InSight, deadNode, escapeNode);// isRestTime);            //pregunta, si se ve al jugador
        ITreeNode isClose = new QuestionNode(IsClose, isInSight, idleNode);

        _root = isClose;                 //La pregunta base del árbol es si el jugador está a la vista
    }
    
    void TransitionToIdle()
    {
        _fsm.Transition(States.Idle);
    }
    void TransitionToEscape()
    {
        _fsm.Transition(States.Escape);
    }
    void TransitionToDead()
    {
        _fsm.Transition(States.Dead);
    }
    
    bool InSight()
    {
        Debug.Log("Check in sight");
        if (_player == null) return false;
        return _npc.IsInSight(_player.transform);
    }

    bool IsClose()
    {
        if (_player == null) return false;
        return Vector3.Distance(transform.position, _player.transform.position) < _npc.playerEscapeRange;
    }
    
    bool IsDead()
    {
        return _npc.isDead;
    }
}
