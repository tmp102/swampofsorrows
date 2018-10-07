using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Storyline", menuName = "Storyline")]
    public class Storyline : ScriptableObject
    {
        [SerializeField]
        private List<State> m_States = new List<State>();

        public List<State> states
        {
            get
            {
                return m_States;
            }
        }
    }
}
