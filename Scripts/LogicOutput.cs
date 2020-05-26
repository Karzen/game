using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicOutput : MonoBehaviour
{

    public bool negate = false;

    List<LogicEntry> inputs = new List<LogicEntry>();

    private bool currentState = false;


    void Start()
    {
        setState(getState());
        Debug.Log("haidee");
    }

    public bool getState()
    {
        if(negate)
            return !currentState;
        return currentState;
    }

    public void setLogicInput(LogicEntry logicInput)
    {
        inputs.Add(logicInput);
        Debug.Log("LI set");
    }

    public void setState(bool state)
    {
        if (state != currentState)
        {
            foreach(LogicEntry input in inputs) {
                if (input != null)
                {
                    currentState = state;
                    input.refresh();
                    Debug.Log("refreshed");

                }
            }
        }
    }
}