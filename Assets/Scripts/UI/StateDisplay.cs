using System;
using System.Collections;
using System.Collections.Generic;
using Narrative;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StateDisplay : MonoBehaviour, IStateDisplay
{
    [Serializable]
    public class OptionSelectedEvent : UnityEvent<Transition> { }

    [SerializeField]
    private Text _titleText;
    public Text titleText
    {
        get
        {
            return _titleText;
        }
        set
        {
            _titleText = value;
        }
    }

    [SerializeField]
    private Text _descriptionText;
    public Text descriptionText
    {
        get
        {
            return _descriptionText;
        }
        set
        {
            _descriptionText = value;
        }
    }

    [SerializeField]
    private OptionList _optionList;
    public OptionList optionList
    {
        get
        {
            return _optionList;
        }
        set
        {
            _optionList = value;
        }
    }

    public string title
    {
        get
        {
            return _titleText.text;
        }
        set
        {
            _titleText.text = value;
        }
    }

    public string description
    {
        get
        {
            return _descriptionText.text;
        }
        set
        {
            _descriptionText.text = value;
        }
    }

    public List<Transition> options
    {
        get
        {
            return _optionList.options;
        }
        set
        {
            _optionList.options = value;
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

    public void Display(State state)
    {
        state.DisplayOn(this);
    }

    public void OnOptionSelected(Transition option)
    {
        onOptionSelected.Invoke(option);
    }
}
