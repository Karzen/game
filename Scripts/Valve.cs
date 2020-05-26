using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 rotation;
    public bool oneWay = false;

    LogicOutput logicOutput;
    Quaternion Initial;
    Quaternion current;

    private bool state;

    private void Start()
    {
        logicOutput = this.GetComponent<LogicOutput>();

        Initial = transform.rotation;

        current = Initial;
    }

    public void Interact()
    {
        if (oneWay)
        {
            setState(true);
        }
        else
        {
            if (!state)
            {
                setState(true);
            }
            else
            {
                setState(!state);
            }
        }
    }

    private void setState(bool state)
    {
        this.state = state;
        logicOutput.setState(state);
        if (state)
        {
            current = Quaternion.Euler(rotation);
        }
        else
        {
            current = Initial;
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, current, speed);
    }





}
