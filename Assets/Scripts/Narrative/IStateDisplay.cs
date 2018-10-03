using Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateDisplay
{
    string Title { get; set; }
    string Description { get; set; }
    List<Transition> Options { get; set; }
}
