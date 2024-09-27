using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueEvent
{
    [field: SerializeField] public List<Dialogue> Dialogues {  get; private set; }
}
