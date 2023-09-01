﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionNode : ITreeNode
{
    Action _action;
    public ActionNode(Action action)
    {
        _action = action;
    }
    public void Execute()
    {
        _action?.Invoke();
    }
}
