using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Option", menuName = "Transitions/Option")]
    public class Option : Transition
    {
        [SerializeField]
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public override void DisplayOn(ITransitionDisplay display)
        {
            display.Description = Description;
        }
    }
}
