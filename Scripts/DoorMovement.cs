using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorMovement : MonoBehaviour
{
    public Vector3 Opened;

    public float speed = 1f;

    public bool invert      = false;
    public bool isPlayerOut = false;

    public List<NavMeshObstacle> EnterBarriers = new List<NavMeshObstacle>();
    public List<NavMeshObstacle> ExitBarriers  = new List<NavMeshObstacle>();

    private Quaternion Closed;
    private Quaternion current;

    private bool currentState;

    public void setPlayerAreaPosition(bool state)
    {
        isPlayerOut = state;
       
        if (!currentState)
            CalculateAreas();       
    }

    public void setState(bool state)
    {
        if (invert)
            state = !state;

        currentState = state;
        if (state)
        {
            Debug.Log("SET IN PULA MEA");
            setEnterBarriers(false);
            setExitBarriers(false);
            current = Quaternion.Euler(Opened);
        }
        else
        {
            Debug.Log("MUIE IN PULA MEA DE PROIECT CA MA FUT IN EL");
            CalculateAreas();
            current = Closed;
        }
    }

    private void CalculateAreas()
    {
        Debug.Log("PIZDA SI COAIE " + isPlayerOut);
        
        if (isPlayerOut)
        {
            setExitBarriers(true);
            setEnterBarriers(false);
        }
        else
        {
            setExitBarriers(true);
            setEnterBarriers(false);
        }
        
    }

    private void setEnterBarriers(bool state)
    {
        foreach (NavMeshObstacle barrier in EnterBarriers)
        {
            if (barrier != null)
                barrier.enabled = state;
        }
    }
    private void setExitBarriers(bool state)
    {
        foreach(NavMeshObstacle barrier in ExitBarriers)
        {
            if (barrier != null)
                barrier.enabled = state;
        }
    }

    void FixedUpdate()
    {
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, current, speed);   
    }
    
    private void Start()
    {
        if (!invert)
        {
            Closed = transform.rotation;
            current = Closed;
        }
        else
        {
            Closed = Quaternion.Euler(Opened);
            Opened = transform.rotation.ToEuler();
            current = Closed;
        }
    }
}
