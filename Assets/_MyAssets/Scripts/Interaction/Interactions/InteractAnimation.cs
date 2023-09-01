using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractAnimation : InteractionBase//, IInteractable
{
    [SerializeField] private Animation anim;
    
    [SerializeField] private EventID interactionId;
    [SerializeField] LookTarget newLookTarget;
    private LookTarget _lookTarget;
    

    
    

    
    void Start()
    {
        TryGetComponent<LookTarget>(out _lookTarget);
        TryGetComponent<EventID>(out interactionId);

    }
    
    void Update()
    {
        
    }

    public override void Interact()
    {
        base.Interact();
        
        // Si existe un target nuevo para reemplazar por este al interactuar
        if(newLookTarget) _lookTarget.StopTargeting(newLookTarget.transform);
        else _lookTarget.StopTargeting();
        
        interacted = true;
        if(interactionId) GameManager.instance.PlayerInteracted(interactionId.id, this);
        
        anim.Play();
        
    }
    
    
    
    

    
}
