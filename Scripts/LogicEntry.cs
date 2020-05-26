using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicEntry: MonoBehaviour
{
    // Start is called before the first frame update
    public List<LogicOutput> outputs = new List<LogicOutput>();
    public string logicGate = "and";

    private bool state = false;


    public void refresh()
    {


        bool currentState = outputs[0].getState();


        Debug.Log("refreshing");

        for (int i = 1; i < outputs.Count; i++)
        {
            if (logicGate.Equals("and"))
            {
                currentState = currentState && outputs[i].getState();
            }
            else if (logicGate.Equals("or"))
            {
                currentState = currentState || outputs[i].getState();
            }
            else if (logicGate.Equals("xor"))
            {
                currentState = currentState ^ outputs[i].getState();
            }



        }

        execute(currentState);

    }


    public virtual void execute(bool state)
    {

    }

    public void Start()
    {
        foreach (LogicOutput output in outputs)
        {
            output.setLogicInput(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
