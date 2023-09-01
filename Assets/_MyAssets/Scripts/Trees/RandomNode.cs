using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNode : ITreeNode
{
    Roulette _roulette;
    Dictionary<ITreeNode, float> _items;
    public RandomNode(Dictionary<ITreeNode, float> items)
    {
        _roulette = new Roulette();
        SetItems(items);
    }
    public RandomNode(Roulette roulette, Dictionary<ITreeNode, float> items)
    {
        _roulette = roulette;
        SetItems(items);
    }
    public void SetItems(Dictionary<ITreeNode, float> items)
    {
        _items = items;
    }
    public void Execute()
    {
        //_roulette.Run(_items).Execute();
        ITreeNode node = _roulette.Run(_items);
        node.Execute();
    }
}
