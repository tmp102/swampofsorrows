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

    private Transition option;
    public Transition Option
    {
        get
        {
            return option;
        }
        set
        {
            option = value;
            Display(option);
        }
    }

    private Button button;
    private Button Button
    {
        get
        {
            return button;
        }
        set
        {
            button = value;
        }
    }

    [SerializeField]
    private Text buttonText;
    public Text ButtonText
    {
        get
        {
            return buttonText;
        }
        set
        {
            buttonText = value;
        }
    }

    public string Description
    {
        get
        {
            return ButtonText.text;
        }
        set
        {
            ButtonText.text = value;
        }
    }

    [SerializeField]
    public ButtonClickedEvent onClick;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    private void OnDisable()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(OnClick);
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
            Description = String.Empty;
        }
    }

    public void OnClick()
    {
        onClick.Invoke(Option);
    }
}
