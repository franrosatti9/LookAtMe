using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDeadState<T> : State<T>
{
    Npc _npc;
    public NpcDeadState(Npc npc)
    {
        _npc = npc;
    }
    public override void Awake()
    {
        //_npc.isChasing = false;
        _npc.Die();
    }
}
