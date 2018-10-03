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
    private Text titleText;
    public Text TitleText
    {
        get
        {
            return titleText;
        }
        set
        {
            titleText = value;
        }
    }

    [SerializeField]
    private Text descriptionText;
    public Text DescriptionText
    {
        get
        {
            return descriptionText;
        }
        set
        {
            descriptionText = value;
        }
    }

    [SerializeField]
    private OptionList optionList;
    public OptionList OptionList
    {
        get
        {
            return optionList;
        }
        set
        {
            optionList = value;
        }
    }

    public string Title
    {
        get
        {
            return titleText.text;
        }
        set
        {
            titleText.text = value;
        }
    }

    public string Description
    {
        get
        {
            return descriptionText.text;
        }
        set
        {
            descriptionText.text = value;
        }
    }

    public List<Transition> Options
    {
        get
        {
            return optionList.Options;
        }
        set
        {
            optionList.Options = value;
        }
    }

    [SerializeField]
    public OptionSelectedEvent onOptionSelected;

    public void Display(State state)
    {
        state.DisplayOn(this);
    }

    public void OnOptionSelected(Transition option)
    {
        onOptionSelected.Invoke(option);
    }
}
