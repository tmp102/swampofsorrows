using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Storyline", menuName = "Storyline")]
    public class Storyline : ScriptableObject
    {
        [SerializeField]
        private List<State> states = new List<State>();
        public List<State> States
        {
            get
            {
                return states;
            }
        }
    }
}
