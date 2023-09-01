using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : PickUp
{
    [SerializeField] ItemsEnum itemType;
    
    // Expandir en el futuro tal vez
    
    public override void OnPickup()
    {
        var inventory = GameManager.instance.GetPlayer.Inventory;
        if (!inventory.HasItem(itemType))
        {
            inventory.AddTool(itemType);
            
            Destroy(this.gameObject);
        }

    }
    
}
