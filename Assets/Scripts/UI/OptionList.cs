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
    private List<OptionButton> _buttons = new List<OptionButton>();
    public List<OptionButton> buttons
    {
        get
        {
            return _buttons;
        }
    }

    public List<Transition> options
    {
        get
        {
            List<Transition> options = new List<Transition>();
            foreach (OptionButton b in _buttons)
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

    [SerializeField]
    private OptionSelectedEvent _onOptionSelected;
    public OptionSelectedEvent onOptionSelected
    {
        get
        {
            return _onOptionSelected;
        }
        set
        {
            _onOptionSelected = value;
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
