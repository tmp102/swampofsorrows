using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Section", menuName = "States/Section")]
    public class Section : State
    {
        [SerializeField]
        private string _title;
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        [SerializeField]
        [TextArea(10, 10)]
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

        [SerializeField]
        private List<Transition> _transitions = new List<Transition>();
        public override List<Transition> transitions
        {
            get
            {
                return _transitions;
            }
        }

        public override void DisplayOn(IStateDisplay display)
        {
            display.title = title;
            display.description = description;
            display.options = transitions;
        }
    }
}
