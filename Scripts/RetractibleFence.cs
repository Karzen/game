using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractibleFence: LogicEntry
{
    public Vector3 finalPosition;

    public float speed                = 1;
    public float closeSpeedMultiplier = 1;

    public AudioSource audioSource;

    private bool retract = false;
    private bool audioPlaying = false;
    private bool last = false;

    private Vector3 initialPosition;

    public override void execute(bool state)
    {
        Debug.Log("We are rolling boysz");
        retract = state;
    }

    private void Start()
    {
        base.Start();
        initialPosition = transform.position;
        finalPosition = transform.position + finalPosition;
    }

    private void FixedUpdate()
    {

        if (retract)
        {
            if (!audioPlaying && transform.position != finalPosition)
            {
                audioSource.Play();
                audioPlaying = true;
            }
            else if ((transform.position == finalPosition) || last != true)
            {
                audioPlaying = false;
                audioSource.Stop();
            }
            last = true;
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, speed);
        }
        else
        {
            if (!audioPlaying  && transform.position != initialPosition)
            {
                audioSource.Play();
                audioPlaying = true;
            }
            else if(transform.position == initialPosition || last != false)
            {
                audioPlaying = false;
                audioSource.Stop();
            }
            last = false;
            
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * closeSpeedMultiplier);
        }
        
    }

}
