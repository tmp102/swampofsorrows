using Narrative;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class StorylineEditor : EditorWindow
{
    private Storyline m_Target;
    private ISelectable m_SelectedItem;

    public Storyline target
    {
        get
        {
            return m_Target;
        }
        set
        {
            m_Target = value;
            Repaint();
        }
    }

    public ISelectable selectedItem
    {
        get
        {
            return m_SelectedItem;
        }
        set
        {
            m_SelectedItem = value;
            Repaint();
        }
    }

    private List<State> states
    {
        get
        {
            if (target != null)
            {
                return m_Target.states;
            }
            else
            {
                return null;
            }
        }
    }

    private List<Transition> transitions
    {
        get
        {
            if (target != null)
            {
                List<Transition> transitions = new List<Transition>();
                foreach (State s in states)
                {
                    transitions.AddRange(s.transitions);
                }
                return transitions;
            }
            else
            {
                return null;
            }
        }
    }

    public static StorylineEditor OpenWindow(Storyline target, string title, bool focus, params System.Type[] desiredDockNextTo)
    {
        StorylineEditor window = GetWindow<StorylineEditor>(title, focus, desiredDockNextTo);
        window.target = target;
        return window;
    }

    public static StorylineEditor OpenWindow(Storyline target)
    {
        return OpenWindow(target, "Storyline", true, typeof(SceneView));
    }

    [MenuItem("Window/Storyline Editor")]
    public static StorylineEditor OpenWindow()
    {
        return OpenWindow(null, "Storyline", true, typeof(SceneView));
    }

    [OnOpenAsset(1)]
    public static bool OnOpenAsset(int instanceID, int line)
    {
        Storyline asset = EditorUtility.InstanceIDToObject(instanceID) as Storyline;
        if (asset != null)
        {
            OpenWindow(asset);
            return true;
        }
        return false;
    }

    private void OnSelectionChange()
    {
        Storyline selection = Selection.activeObject as Storyline;
        if (selection != null)
        {
            target = selection;
        }
    }

    private void OnGUI()
    {
        if (target != null)
        {
            DrawBackground();
            DrawTransitions();
            DrawStates();

            GUILayout.Label(new GUIContent(target.name));

            ProcessEvents(Event.current);
        }

        if (GUI.changed)
        {
            Repaint();
        }
    }

    private void DrawBackground()
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(0.3f, 0.3f, 0.3f));
        texture.Apply();

        GUI.DrawTexture(new Rect(0, 0, maxSize.x, maxSize.y), texture);
    }

    private void DrawStates()
    {
        if (states != null)
        {
            foreach (State s in states)
            {
                s.Draw(s == selectedItem);
            }
        }
    }

    private void DrawTransitions()
    {
        if (transitions != null)
        {
            foreach (Transition t in transitions)
            {
                t.Draw(t == selectedItem);
            }
        }
    }

    private void ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                OnMouseDown(e);
                break;
            case EventType.MouseDrag:
                OnMouseDrag(e);
                break;
        }
    }

    private void OnMouseDown(Event e)
    {
        if (e.button == 0)
        {
            SelectItem(e.mousePosition);

            GUI.changed = true;
        }
    }

    private void OnMouseDrag(Event e)
    {
        State selectedState = selectedItem as State;
        if (selectedState != null)
        {
            Rect rect = selectedState.rect;
            rect.position += e.delta;
            selectedState.rect = rect;

            GUI.changed = true;
        }
    }

    private void SelectItem(Vector2 position)
    {
        ISelectable item = null;

        foreach(Transition t in transitions)
        {
            if (t.selectionBox.Contains(position))
            {
                item = t;
                break;
            }
        }

        foreach(State s in states)
        {
            if (s.selectionBox.Contains(position))
            {
                item = s;
                break;
            }
        }

        if (item == null)
        {
            Selection.activeObject = target;
        }
        else
        {
            Selection.activeObject = item as UnityEngine.Object;
        }

        selectedItem = item;
    }
}
