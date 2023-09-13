using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueObject;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] float typeFrequency;
    [SerializeField] float timeBetweenLines;

    private string[] _currentLines;
    private AudioClip _currentVoiceClip;
    private BaseNpc _currentSpeaker;
    private WaitForSeconds _typeSeconds;
    private WaitForSeconds _lineSeconds;
    private int _index;
    private bool _currentlyPlaying;
    
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        textComponent.text = string.Empty;
        _typeSeconds = new WaitForSeconds(typeFrequency);
        _lineSeconds = new WaitForSeconds(timeBetweenLines);

    }

    public bool StartDialogue(string[] lines, AudioClip voiceClip, BaseNpc speaker)
    {
        if (_currentlyPlaying) return false;
        
        dialogueObject.SetActive(true);
        _currentlyPlaying = true;
        _currentLines = lines;
        _currentVoiceClip = voiceClip;
        _currentSpeaker = speaker;
        _index = 0;
        
        StartCoroutine(TypeLine());
        
        return true;
    }
    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        
        foreach (char c in _currentLines[_index].ToCharArray())
        {
            textComponent.text += c;
            if(!c.Equals(' ')) AudioManager.instance.PlaySfxRandomPitch(_currentVoiceClip);
            yield return _typeSeconds;
        }

        yield return _lineSeconds;
        
        NextLine();
    }
    
    void NextLine()
    {
        if (_index < _currentLines.Length - 1)
        {
            _index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            FinishDialogue();
        }
    }

    void FinishDialogue()
    {
        StopAllCoroutines();
        _currentlyPlaying = false;
        _currentLines = null;
        _currentVoiceClip = null;
        dialogueObject.SetActive(false);
    }

    public void CheckSpeakerDead(BaseNpc dead)
    {
        if(dead == _currentSpeaker) FinishDialogue();
    }
}
