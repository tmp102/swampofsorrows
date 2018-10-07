using Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private StateDisplay _stateDisplay;
    public StateDisplay stateDisplay
    {
        get
        {
            return _stateDisplay;
        }
        set
        {
            _stateDisplay = value;
        }
    }

    [SerializeField]
    private Storyline _storyline;
    public Storyline storyline
    {
        get
        {
            return _storyline;
        }
        set
        {
            _storyline = value;
        }
    }

    private State _currentState;
    public State currentState
    {
        get
        {
            return _currentState;
        }
        private set
        {
            _currentState = value;
            DisplayState(_currentState);
        }
    }

    private void Start()
    {
        currentState = storyline.states[0];
    }

    private void DisplayState(State state)
    {
        stateDisplay.Display(state);
    }

    public void OnOptionSelected(Transition transition)
    {
        currentState = transition.destinationState;
    }
}
