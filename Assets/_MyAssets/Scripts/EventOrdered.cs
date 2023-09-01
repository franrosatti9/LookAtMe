using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOrdered : Event
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CheckProgress(int id)
    {
        if (_eventCompleted) return;
        
        if (CurrentStep.CheckCompletion(id))
        {
            if (_currentStepIndex + 1 >= eventData.StepsAmount)
            {
                CompleteEvent();
                return;
            }
            
            
            CompletedStep(_currentStepIndex);
        }
    }
    
    public override string GetStepsUIText()
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
