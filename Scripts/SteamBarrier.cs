using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamBarrier : LogicEntry
{
    // Start is called before the first frame update
    public override void execute(bool state)
    {
        base.execute(state);

        if (state)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

    }
}
