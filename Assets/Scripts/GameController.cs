using Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private StateDisplay stateDisplay;
    public StateDisplay StateDisplay
    {
        get
        {
            return stateDisplay;
        }
        set
        {
            stateDisplay = value;
        }
    }

    [SerializeField]
    private Storyline storyline;
    public Storyline Storyline
    {
        get
        {
            return storyline;
        }
        set
        {
            storyline = value;
        }
    }

    private State currentState;
    public State CurrentState
    {
        get
        {
            return currentState;
        }
        private set
        {
            currentState = value;
            DisplayState(currentState);
        }
    }

    private void Start()
    {
        CurrentState = Storyline.States[0];
    }

    private void DisplayState(State state)
    {
        StateDisplay.Display(state);
    }

    public void OnOptionSelected(Transition transition)
    {
        CurrentState = transition.DestinationState;
    }
}
