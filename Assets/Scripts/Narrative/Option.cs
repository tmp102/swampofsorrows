using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Option", menuName = "Transitions/Option")]
    public class Option : Transition
    {
        [SerializeField]
        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public override void DisplayOn(ITransitionDisplay display)
        {
            display.description = description;
        }
    }
}
