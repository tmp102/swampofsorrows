using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

        public Vector2 position
        {
            get
            {
                return m_Rect.position;
            }
            set
            {
                m_Rect.position = value;
            }
        }

        public Vector2 size
        {
            get
            {
                return m_Rect.size;
            }
            set
            {
                m_Rect.size = value;
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
                GUIStyle style = new GUIStyle();
                style.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
                style.border = new RectOffset(12, 12, 12, 12);
                GUI.Box(rect, new GUIContent("*"));
            }
            else
            {
                GUIStyle style = new GUIStyle();
                style.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1 on.png") as Texture2D;
                style.border = new RectOffset(12, 12, 12, 12);
                GUI.Box(rect, new GUIContent("*"));
            }
        }
    }
}
