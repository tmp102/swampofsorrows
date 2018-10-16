using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    public abstract class State : ScriptableObject, ISelectable
    {
        [SerializeField]
        private Rect m_Rect = new Rect(0, 0, 200, 50);

        public Rect rect
        {
            get
            {
                return m_Rect;
            }
            set
            {
                m_Rect = value;
            }
        }

        public SelectionBox selectionBox
        {
            get
            {
                return new SelectionBox(rect);
            }
        }

        public abstract List<Transition> transitions { get; }

        public abstract void DisplayOn(IStateDisplay display);

        public virtual void Draw(bool selected = false)
        {
            if (selected)
            {
                GUI.Box(rect, new GUIContent("*"));
            }
            else
            {
                GUI.Box(rect, new GUIContent(String.Empty));
            }
        }
    }
}
