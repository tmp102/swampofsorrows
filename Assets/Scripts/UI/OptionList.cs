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
    private List<OptionButton> buttons = new List<OptionButton>();
    public List<OptionButton> Buttons
    {
        get
        {
            return buttons;
        }
    }

    public List<Transition> Options
    {
        get
        {
            List<Transition> options = new List<Transition>();
            foreach (OptionButton b in buttons)
            {
                if (b.Option != null)
                {
                    options.Add(b.Option);
                }
            }
            return options;
        }
        set
        {
            DisplayOptions(value);
        }
    }

    [SerializeField]
    public OptionSelectedEvent onOptionSelected;

    private void DisplayOptions(List<Transition> options)
    {
        for (int i = 0; i < options.Count && i < Buttons.Count; i++)
        {
            Buttons[i].Option = options[i];
            Buttons[i].gameObject.SetActive(true);
        }
        for (int i = options.Count; i < Buttons.Count; i++)
        {
            Buttons[i].gameObject.SetActive(false);
            Buttons[i].Option = null;
        }
    }

    public void OnOptionSelected(Transition option)
    {
        onOptionSelected.Invoke(option);
    }
}
