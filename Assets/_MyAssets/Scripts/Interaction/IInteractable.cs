using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    void Highlight();
    void StopHighlight();
    string GetInteractText();
    bool Interacted();
    bool Highlighted();
    
}
