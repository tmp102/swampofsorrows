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

    private Transition _option;
    public Transition option
    {
        get
        {
            return _option;
        }
        set
        {
            _option = value;
            Display(_option);
        }
    }

    private Button _button;
    private Button button
    {
        get
        {
            return _button;
        }
        set
        {
            _button = value;
        }
    }

    [SerializeField]
    private Text _buttonText;
    public Text buttonText
    {
        get
        {
            return _buttonText;
        }
        set
        {
            _buttonText = value;
        }
    }

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

    [SerializeField]
    private ButtonClickedEvent _onClick;
    public ButtonClickedEvent onClick
    {
        get
        {
            return _onClick;
        }
        set
        {
            _onClick = value;
        }
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (_button != null)
        {
            _button.onClick.AddListener(OnClick);
        }
    }

    private void OnDisable()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(OnClick);
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
