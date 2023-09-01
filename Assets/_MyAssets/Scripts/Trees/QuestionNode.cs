using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestionNode : ITreeNode
{
    Func<bool> _question;
    ITreeNode _tNode;
    ITreeNode _fNode;

    public QuestionNode(Func<bool> question, ITreeNode tNode, ITreeNode fNode)  //pasamos la pregunta, la acción si es true, y la acción si es false
    {
        _question = question;
        _tNode = tNode;
        _fNode = fNode;
    }
    public void Execute()
    {
        if (_question != null && _question())
        {
            _tNode.Execute();
        }
        else
        {
            _fNode.Execute();
        }
    }
}
