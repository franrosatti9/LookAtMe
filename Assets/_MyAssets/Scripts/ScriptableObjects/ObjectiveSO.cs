using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Objective", fileName = "New Objective")]
public class ObjectiveSO : ScriptableObject
{
    public string stepDescription;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckCompletion()
    {
        return true;
    }
    
}

public enum ObjectiveType{
    
}
