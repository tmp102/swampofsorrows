using System;
using System.Collections;
using System.Collections.Generic;
using Narrative;
using UnityEngine;
using UnityEngine.Events;

public class OptionList : MonoBehaviour
{
    [Serializable]
    public class OptionSelectedEvent : UnityEvent<Transition> { }

    [SerializeField]
    private List<OptionButton> m_Buttons = new List<OptionButton>();

    [SerializeField]
    private OptionSelectedEvent m_OnOptionSelected;

    public List<Transition> options
    {
        get
        {
            List<Transition> options = new List<Transition>();
            foreach (OptionButton b in m_Buttons)
            {
                if (b.option != null)
                {
                    options.Add(b.option);
                }
            }
            return options;
        }
        set
        {
            DisplayOptions(value);
        }
    }

    public List<OptionButton> buttons
    {
        get
        {
            return m_Buttons;
        }
    }

    public OptionSelectedEvent onOptionSelected
    {
        get
        {
            return m_OnOptionSelected;
        }
        set
        {
            m_OnOptionSelected = value;
        }
    }

    private void DisplayOptions(List<Transition> options)
    {
        for (int i = 0; i < options.Count && i < buttons.Count; i++)
        {
            buttons[i].option = options[i];
            buttons[i].gameObject.SetActive(true);
        }
        for (int i = options.Count; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
            buttons[i].option = null;
        }
    }

    public void OnOptionSelected(Transition option)
    {
        onOptionSelected.Invoke(option);
    }
}
