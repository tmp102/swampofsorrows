using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Transitions/Transition")]
    public class Transition : ScriptableObject
    {
        [SerializeField]
        private State m_SourceState;

        [SerializeField]
        private State m_DestinationState;

        public State sourceState
        {
            get
            {
                return m_SourceState;
            }
            set
            {
                m_SourceState = value;
            }
        }

        public State destinationState
        {
            get
            {
                return m_DestinationState;
            }
            set
            {
                m_DestinationState = value;
            }
        }

        public virtual void DisplayOn(ITransitionDisplay display)
        {
            display.description = "Next...";
        }
    }
}