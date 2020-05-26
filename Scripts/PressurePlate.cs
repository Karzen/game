using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    private int inputIndex;
    private int all = 0;

    public Light activeLight;

    public Material OnMaterial;
    public Material OffMaterial;


    public LogicOutput logicOutput;

    public List<GameObject> colisions = new List<GameObject>();

    void Start()
    {
        setPressureActive(false);
    }

    private void setPressureActive(bool checkbool)
    {
        if (checkbool)
        {
            activeLight.enabled = true;
            this.GetComponent<MeshRenderer>().material = OnMaterial;
            logicOutput.setState(true);
            
        }
        else
        {
            activeLight.enabled = false;
            this.GetComponent<MeshRenderer>().material = OffMaterial;
            logicOutput.setState(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            if (other.tag == "Player")
                other.GetComponent<MovePlayer>().pressurePlate = null;
            colisions.Remove(other.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            if (other.tag == "Player")
                other.GetComponent<MovePlayer>().pressurePlate = this;
            colisions.Add(other.gameObject);
        }  
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < colisions.Count; i++)
        {
            if (colisions[i] == null)
            {
                colisions.RemoveAt(i);
            }
        }
        if (colisions.Count > 0)
        {
            setPressureActive(true);
        }
        else
        {
            setPressureActive(false);
        }
    }
}
