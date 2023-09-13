using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSimple : InteractionBase
{
    //[SerializeField] private Animation anim;
    [SerializeField] private GameObject collidersToDeactivate;

    protected override void Start()
    {
        base.Start();
        TryGetComponent<Animation>(out anim);
    }

    public override void Interact()
    {
        base.Interact();
        //interacted = true;
        if(collidersToDeactivate != null) collidersToDeactivate.SetActive(false);
       
    }

    
}
