using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : LogicEntry
{
    Animator doorAnimator;
    public ExitPoint finish;

    public override void execute(bool state)
    {

        this.GetComponentInParent<DoorMovement>().setState(state);

        if(finish != null)
            finish.setEnabled(state);
    }

    void Start()
    {
        base.Start();
    }
}
