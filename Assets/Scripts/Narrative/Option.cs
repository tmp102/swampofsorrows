using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Option", menuName = "Transitions/Option")]
    public class Option : Transition
    {
        [SerializeField]
        private string m_Description;

        public string description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }

        public override void DisplayOn(ITransitionDisplay display)
        {
            display.description = description;
        }
    }
}
