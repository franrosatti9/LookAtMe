using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Npc Voice Clips", fileName = "New Voice Clips")]
public class NpcVoiceClips : ScriptableObject
{
    [SerializeField] AudioClip dialogueClip;
    [SerializeField] AudioClip screamClip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
