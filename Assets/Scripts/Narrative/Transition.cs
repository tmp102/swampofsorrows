using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Transitions/Transition")]
    public class Transition : ScriptableObject
    {
        [SerializeField]
        private State _sourceState;
        public State sourceState
        {
            get
            {
                return _sourceState;
            }
            set
            {
                _sourceState = value;
            }
        }

        [SerializeField]
        private State _destinationState;
        public State destinationState
        {
            get
            {
                return _destinationState;
            }
            set
            {
                _destinationState = value;
            }
        }

        public virtual void DisplayOn(ITransitionDisplay display)
        {
            // do nothing
        }
    }
}