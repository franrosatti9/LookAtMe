using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EventData
{
    public string eventName;
    public event Action OnStepCompleted;
    public event Action<Transform> OnEventCompleted;
    [SerializeField] private Objective[] steps;
    private int _currentStepIndex = 0;

    public Objective CurrentStep => steps[_currentStepIndex];
    void Start()
    {
        Debug.Log("start event data");
    }

    // Update is called once per frame
    void Update()
    {
        //if (CurrentStep.CheckCompletion())
        //{
            _currentStepIndex++;
            Debug.Log("Step completed");
            OnStepCompleted?.Invoke();
            
            if (_currentStepIndex > steps.Length)
            {
                //OnEventCompleted?.Invoke();
            }
        //}
        
    }

    public string GetStepsUIText()
    {
        // Si vamos mas de un paso, significa que el primero fue completado, por lo tanto hacemos que se vea verde
        string text = _currentStepIndex > 0 ? "<color=green>" : "";
        for (int i = 0; i < _currentStepIndex; i++)
        {
            if (i == _currentStepIndex - 1) text += "- " + steps[i].stepDescription + "</color> \n";
            if (i == _currentStepIndex) text += "- " + steps[i].stepDescription;
            else text += "- " + steps[i].stepDescription + "\n";
        }
        
        //Debug.Log(steps.Length);
        
        return text;
    }
}
