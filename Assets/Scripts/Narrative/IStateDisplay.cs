using Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateDisplay
{
    string title { get; set; }
    string description { get; set; }
    List<Transition> options { get; set; }
}
