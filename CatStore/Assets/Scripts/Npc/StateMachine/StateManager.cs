using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;
    private State nextState;
    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        //GameObject.FindWithTag("target").GetComponent<TextMeshProUGUI>().text = "statemachine running: " + transform.name + ": " + currentState.ToString() + ": " + nextState.ToString();
        nextState = currentState.RunCurrentState();

        //GameObject.FindWithTag("target").GetComponent<TextMeshProUGUI>().text = "statemachine running: " + transform.name + ": " + currentState.ToString() + ": " + nextState.ToString();

        //GameObject.FindWithTag("target").GetComponent<TextMeshProUGUI>().text = "statemachine running: " + transform.name + ": " + nextState.ToString();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
