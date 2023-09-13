using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTargetAnimation : InteractionBase //, IInteractable
{
    [SerializeField] private Animation anim;
    [SerializeField] LookTarget newLookTarget;
    
    private LookTarget _lookTarget;

    protected override void Start()
    {
        base.Start();
        TryGetComponent<LookTarget>(out _lookTarget);
    }

    public override void Interact()
    {
        base.Interact();
        
        // Si existe un target nuevo para reemplazar por este al interactuar
        if(newLookTarget) _lookTarget.StopTargeting(newLookTarget.transform);
        else _lookTarget.StopTargeting();
        
        //interacted = true;
        anim.Play();
    }
}
