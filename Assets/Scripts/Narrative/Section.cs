﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Section", menuName = "States/Section")]
    public class Section : State
    {
        [SerializeField]
        private string m_Title;

        [SerializeField]
        [TextArea(10, 10)]
        private string m_Description;

        [SerializeField]
        private List<Transition> m_Transitions = new List<Transition>();

        public string title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

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

        public override List<Transition> transitions
        {
            get
            {
                return m_Transitions;
            }
        }

        public override void DisplayOn(IStateDisplay display)
        {
            display.title = title;
            display.description = description;
            display.options = transitions;
        }

        public override void Draw(bool selected = false)
        {
            if (selected)
            {
                GUI.Box(rect, new GUIContent(title + "*"));
            }
            else
            {
                GUI.Box(rect, new GUIContent(title));
            }
        }
    }
}
