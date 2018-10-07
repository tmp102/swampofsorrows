using Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private StateDisplay m_StateDisplay;

    [SerializeField]
    private Storyline m_Storyline;

    private State m_CurrentState;

    public StateDisplay stateDisplay
    {
        get
        {
            return m_StateDisplay;
        }
        set
        {
            m_StateDisplay = value;
        }
    }

    public Storyline storyline
    {
        get
        {
            return m_Storyline;
        }
        set
        {
            m_Storyline = value;
        }
    }

    public State currentState
    {
        get
        {
            return m_CurrentState;
        }
        private set
        {
            m_CurrentState = value;
            DisplayState(m_CurrentState);
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
