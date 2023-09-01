using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIdleState<T> : State<T>
{
    Npc _npc;
    ITreeNode _root;

    public NpcIdleState(Npc npc, ITreeNode root)
    {
        _npc = npc;
        _root = root;
    }

    public override void Awake()
    {
        //Debug.Log("Is Idling");
        //_enemy.StartIdle();
        _npc.Move(Vector3.zero);
    }
    public override void Execute()
    {
        _root.Execute();
    }

    public override void Sleep()
    {
        //_enemy.StopIdle();
    }
}