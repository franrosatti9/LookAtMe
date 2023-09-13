using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUnordered : Event
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public override void CheckProgress(int id)
    {
        //if (_eventCompleted) return;
        Debug.Log("Checking steps");
        
        for (int i = 0; i < eventData.StepsAmount; i++)
        {
            if(eventData.Steps[i].completed) continue;
            
            if (eventData.Steps[i].CheckCompletion(id))
            {
                CompletedStep(i);
            }
        }
        
        if (_completedSteps >= eventData.StepsAmount)
        {
            CompleteEvent();
            return;
        }
    }
    
    public override string GetStepsUIText()
    {
        // Capaz cambiar Done por variable del SO que diga mensaje al finalizar
        if (_eventCompleted) return "<color=green>Done!</color>";
        
        string text = "";
        
        // Chequeamos cada paso, si esta completado, lo agregamos con verde, sino en blanco
        for (int i = 0; i < eventData.StepsAmount; i++)
        {
            Debug.Log("Chequeando " + eventData.Steps[i].stepDescription + ": " + eventData.Steps[i].completed);
            if (eventData.Steps[i].completed)
                text += "<color=green>- " + eventData.Steps[i].stepDescription + "</color> \n";
            else text += "- " + eventData.Steps[i].stepDescription + "\n";
        }

        return text;
    }
}
