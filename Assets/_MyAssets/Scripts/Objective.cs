using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Objective
{
    public string stepDescription;
    public int neededInteractionId;
    public bool completed = false;

    public bool CheckCompletion(int id)
    {
        return GameManager.instance.interactedDictionary.ContainsKey(neededInteractionId);
    }
}
