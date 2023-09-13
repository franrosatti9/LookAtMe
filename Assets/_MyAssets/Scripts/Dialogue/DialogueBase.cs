using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBase : MonoBehaviour
{
    [SerializeField] private string[] lines;
    [SerializeField] private AudioClip voiceClip;
    private bool _played = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        if(!_played) _played = DialogueManager.instance.StartDialogue(lines, voiceClip, GetComponent<BaseNpc>());
    }
}
