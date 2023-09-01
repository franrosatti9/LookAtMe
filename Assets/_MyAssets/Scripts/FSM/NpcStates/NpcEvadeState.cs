using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcEvadeState<T> : State<T>
{
    Npc _npc;
    GameObject _player;
    ObstacleAvoidance _obs;
    ISteering _steering;
    ITreeNode _root;
    //Action<Node, Node> _setPath;
    //Agent _agent;
    float _timer;

    public NpcEvadeState(Npc npc, GameObject player, ISteering steering, ObstacleAvoidance obs, ITreeNode root)
    {
        _npc = npc;
        _player = player;
        _steering = steering;
        _obs = obs;
        _root = root;
    }

    public override void Awake()                  //Cambiamos la velocidad para la persecución, al igual que la animación y lockeamos que persiga al personaje a pesar de los obstáculos
    {
        _npc.speed = 3f;
        _npc.anim.SetBool("Escaping", true);
        //_npc.isChasing = true;
        //_npc.wasEscaping = true;
    }

    public override void Execute()                //Función de persecución al jugador
    {
        if (_player == null) return;
        var dir = _obs.GetDir(_steering.GetDir());
        _npc.Move(dir);
        _npc.LookDir(dir);
        
        // Buscar como no chequear cada frame
        _root.Execute();
    }

    public override void Sleep()
    {
        _npc.anim.SetBool("Escaping", false);
    }
}
