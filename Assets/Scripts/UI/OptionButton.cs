using System;
using System.Collections;
using System.Collections.Generic;
using Narrative;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OptionButton : MonoBehaviour, ITransitionDisplay
{
    [Serializable]
    public class ButtonClickedEvent : UnityEvent<Transition> { }

    private Transition m_Option;

    private Button m_Button;

    [SerializeField]
    private Text m_ButtonText;

    [SerializeField]
    private ButtonClickedEvent m_OnClick;

    public string description
    {
        get
        {
            return buttonText.text;
        }
        set
        {
            buttonText.text = value;
        }
    }

    public Transition option
    {
        get
        {
            return m_Option;
        }
        set
        {
            m_Option = value;
            Display(m_Option);
        }
    }

    private Button button
    {
        get
        {
            return m_Button;
        }
        set
        {
            m_Button = value;
        }
    }

    public Text buttonText
    {
        get
        {
            return m_ButtonText;
        }
        set
        {
            m_ButtonText = value;
        }
    }

    public ButtonClickedEvent onClick
    {
        get
        {
            return m_OnClick;
        }
        set
        {
            m_OnClick = value;
        }
    }

    private void Awake()
    {
        m_Button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (m_Button != null)
        {
            m_Button.onClick.AddListener(OnClick);
        }
    }

    private void OnDisable()
    {
        if (m_Button != null)
        {
            m_Button.onClick.RemoveListener(OnClick);
        }
    }

    private void Display(Transition option)
    {
        if (option != null)
        {
            option.DisplayOn(this);
        }
        else
        {
            description = String.Empty;
        }
    }

    public void OnClick()
    {
        onClick.Invoke(option);
    }
}
