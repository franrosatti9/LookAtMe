using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour, IInteractable
{
    [SerializeField] protected string interactionText;
    [SerializeField] protected bool interactedWhenAnimationCompleted;
    [SerializeField] protected Animation anim;
    
    protected EventID interactionId = null;
    protected bool interacted = false;
    protected bool highlighted = false;
    
    public bool Interacted() => interacted;
    public bool Highlighted() => highlighted;
    
    [SerializeField] protected ItemsEnum requiredItem;
    protected virtual void Start()
    {
        TryGetComponent<EventID>(out interactionId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Interact()
    {
        if (!PlayerHasRequiredItem()) return;
        interacted = true;
        anim.Play();
        if (interactionId != null)
        {
            // Si hay que esperar para avisar que se completo el paso del evento, se inicia la corrutina
            if (!interactedWhenAnimationCompleted) GameManager.instance.PlayerInteracted(interactionId.id, this);
            else StartCoroutine(WaitOnCompleteAnimation());
        }
        
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
    
    IEnumerator WaitOnCompleteAnimation()
    {
        while (anim.isPlaying)
        {
            yield return null;
        }
        
        GameManager.instance.PlayerInteracted(interactionId.id, this);
    }
}
