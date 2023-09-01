using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour, IPickupeable
{
    private SphereCollider _collider;
    void Start()
    {
        
    }

    public abstract void OnPickup();
    protected void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<PlayerInventory>();

        if (inventory)
        {
            OnPickup();
        }
        
  
    }
}
