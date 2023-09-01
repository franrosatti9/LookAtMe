using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    //public event Action<Transform> OnEventCompleted;
    public EventSO eventData;
    public event Action OnStepCompleted;
    
    [SerializeField] protected Transform newObjectToLookAt;
    [SerializeField] protected Animation[] animations;
    [SerializeField] protected Collider area;
    
    protected bool _eventCompleted = false;
    protected int _currentStepIndex = 0;
    protected int _completedSteps = 0;
    protected bool _playerInArea;
    public Objective CurrentStep => eventData.Steps[_currentStepIndex];


    private void OnEnable()
    {
        //eventData.OnStepCompleted += HandleEventProgress;
        //eventData.OnEventCompleted += CompleteEvent;
        GameManager.instance.OnPlayerInteracted += CheckProgress;
    }

    private void OnDisable()
    {
        //eventData.OnEventCompleted -= CompleteEvent;
        GameManager.instance.OnPlayerInteracted -= CheckProgress;
    }

    void Update()
    {
        
    }

    public virtual void CheckProgress(int id)
    {
        
    }


    protected void HandleEventProgress()
    {
        UIManager.instance.DisplayCurrentEvent(this);
    }

    public virtual void CompleteEvent()
    {
        _eventCompleted = true;
        HandleEventProgress();
        //OnEventCompleted?.Invoke(newObjectToLookAt);
        eventData.Complete(newObjectToLookAt);
    }

    protected virtual void CompletedStep(int index)
    {
        _completedSteps++;
        eventData.Steps[index].completed = true;
        OnStepCompleted?.Invoke();
        HandleEventProgress();
        if(_currentStepIndex < eventData.StepsAmount - 1) _currentStepIndex++;
    }

    protected void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();

        if (player)
        {
            _playerInArea = true;
            HandleEventProgress();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<Player>();

        if (player)
        {
            _playerInArea = false;
            UIManager.instance.HideCurrentEvent();
        }
    }
    
    public virtual string GetStepsUIText()
    {
        if (_eventCompleted) return "<color=green>Done!</color>";
        
        // Si vamos mas de un paso, significa que el primero fue completado, por lo tanto hacemos que se vea verde
        string text = _currentStepIndex > 0 ? "<color=green>" : "";
        for (int i = 0; i <= _currentStepIndex; i++)
        {
            // Para el penultimo paso, cerramos el color verde
            if (i == _currentStepIndex - 1) text += "- " + eventData.Steps[i].stepDescription + "</color> \n";
            // Para el ultimo paso y los anteriores, simplemente agregamos la linea
            else if (i == _currentStepIndex) text += "- " + eventData.Steps[i].stepDescription;
            else text += "- " + eventData.Steps[i].stepDescription + "\n";
        }

        return text;
    }
    
}
