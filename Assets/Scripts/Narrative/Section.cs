using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Section", menuName = "States/Section")]
    public class Section : State
    {
        [SerializeField]
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        [SerializeField]
        [TextArea(10, 10)]
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

        [SerializeField]
        private List<Transition> transitions = new List<Transition>();
        public override List<Transition> Transitions
        {
            get
            {
                return transitions;
            }
        }

        public override void DisplayOn(IStateDisplay display)
        {
            display.Title = Title;
            display.Description = Description;
            display.Options = Transitions;
        }
    }
}
