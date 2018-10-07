using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    public abstract class State : ScriptableObject
    {
        public abstract List<Transition> transitions { get; }

        public abstract void DisplayOn(IStateDisplay display);
    }
}
