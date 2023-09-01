using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    HashSet<ItemsEnum> _items = new HashSet<ItemsEnum>();

    public HashSet<ItemsEnum> Items => _items;


    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public bool HasItem(ItemsEnum item)
    {
        // Si tiene el item o no se pide ninguno, se devuelve true
        return _items.Contains(item) || item == ItemsEnum.None;
    }

    public void AddTool(ItemsEnum item)
    {
        if (_items.Contains(item)) return;
        _items.Add(item);
        Debug.Log("Grabbed " + item);
    }
}

public enum ItemsEnum
{
    None,
    Axe,
    Shovel,
    Pickaxe,
    Flashlight
}
