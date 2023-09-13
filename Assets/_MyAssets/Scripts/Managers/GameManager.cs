using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Player _player;

    public event Action<int> OnPlayerInteracted;
    public event Action OnNpcDeath;
    public Dictionary<int, IInteractable> interactedDictionary = new Dictionary<int, IInteractable>();
    [FormerlySerializedAs("remainingNpcs")] public int killedNpcs;
    private int initialAliveNpcs;
    public Player GetPlayer => _player;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Start()
    {
        initialAliveNpcs = GameObject.FindObjectsOfType<BaseNpc>().Length;
        killedNpcs = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerInteracted(int id, IInteractable interactedWith)
    {
        interactedDictionary.TryAdd(id, interactedWith);
        
        OnPlayerInteracted?.Invoke(id);
        Debug.Log("invoked event");
    }

    public void NpcDead()
    {
        killedNpcs++;
        OnNpcDeath?.Invoke();
    }

    public float GetProgressPercentage()
    {
        return (float)Math.Round(((float)killedNpcs / initialAliveNpcs) * 100, 2);
    }
}
