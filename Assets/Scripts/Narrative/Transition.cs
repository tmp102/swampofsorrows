using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Transitions/Transition")]
    public class Transition : ScriptableObject
    {
        [SerializeField]
        private State sourceState;
        public State SourceState
        {
            get
            {
                return sourceState;
            }
            set
            {
                sourceState = value;
            }
        }

        [SerializeField]
        private State destinationState;
        public State DestinationState
        {
            get
            {
                return destinationState;
            }
            set
            {
                destinationState = value;
            }
        }

        public virtual void DisplayOn(ITransitionDisplay display)
        {
            // do nothing
        }
    }
}