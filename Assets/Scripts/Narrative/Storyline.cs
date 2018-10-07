using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Storyline", menuName = "Storyline")]
    public class Storyline : ScriptableObject
    {
        [SerializeField]
        private List<State> _states = new List<State>();
        public List<State> states
        {
            get
            {
                return _states;
            }
        }
    }
}
