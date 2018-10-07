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
    private Text m_TitleText;

    [SerializeField]
    private Text m_DescriptionText;

    [SerializeField]
    private OptionList m_OptionList;

    [SerializeField]
    private OptionSelectedEvent m_OptionSelected;

    public string title
    {
        get
        {
            return m_TitleText.text;
        }
        set
        {
            m_TitleText.text = value;
        }
    }

    public string description
    {
        get
        {
            return m_DescriptionText.text;
        }
        set
        {
            m_DescriptionText.text = value;
        }
    }

    public List<Transition> options
    {
        get
        {
            return m_OptionList.options;
        }
        set
        {
            m_OptionList.options = value;
        }
    }

    public Text titleText
    {
        get
        {
            return m_TitleText;
        }
        set
        {
            m_TitleText = value;
        }
    }

    public Text descriptionText
    {
        get
        {
            return m_DescriptionText;
        }
        set
        {
            m_DescriptionText = value;
        }
    }

    public OptionList optionList
    {
        get
        {
            return m_OptionList;
        }
        set
        {
            m_OptionList = value;
        }
    }

    public OptionSelectedEvent onOptionSelected
    {
        get
        {
            return m_OptionSelected;
        }
        set
        {
            m_OptionSelected = value;
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
