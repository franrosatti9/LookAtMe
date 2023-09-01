using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour, IInteractable
{
    [SerializeField] protected string interactionText;
    protected bool interacted = false;
    protected bool highlighted = false;
    
    public bool Interacted() => interacted;
    public bool Highlighted() => highlighted;
    
    [SerializeField] protected ItemsEnum requiredItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Interact()
    {
        if (!PlayerHasRequiredItem()) return;
        interacted = true;
    }
    
    public void Highlight()
    {
        if (highlighted) return;
        UIManager.instance.ShowInteraction(this);
        highlighted = true;
    }

    public void StopHighlight()
    {
        if(!highlighted) return;
        UIManager.instance.HideInteraction();
        highlighted = false;
        
    }
    
    public string GetInteractText()
    {
        return PlayerHasRequiredItem()
            ? interactionText
            : interactionText + "<color=red>\n Requires " + requiredItem + "</color>";
    }
    
    protected bool PlayerHasRequiredItem()
    {
        return GameManager.instance.GetPlayer.Inventory.HasItem(requiredItem);
    }
}
