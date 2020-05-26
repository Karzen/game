using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invert : LogicEntry
{
    private LogicOutput logicOutput;

    public override void execute(bool state)
    {
        logicOutput.setState(!state);
        //Debug.Log("Haidee cu inverterul");
    }

    void Start()
    {
        base.Start();
        logicOutput = this.GetComponent<LogicOutput>();
    }
}
