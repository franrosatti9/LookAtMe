using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Event", fileName = "New Event")]
public class EventSO : ScriptableObject
{
    public string eventName;
    public event Action<Transform> OnEventCompleted;
    [SerializeField] private Objective[] steps;
    public Objective[] Steps => steps;
    public int StepsAmount => steps.Length;
    void Start()
    {
        
    }
    
    void Update()
    {

    }

    public void Complete(Transform newTransform)
    {
        OnEventCompleted?.Invoke(newTransform);
    }
    
}
