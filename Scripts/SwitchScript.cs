using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    public GameObject button;

    public Vector3 rotationOffset;

    public List<AudioClip> buttonDownSounds =  new List<AudioClip>();
    public List<AudioClip> buttonUpSounds = new List<AudioClip>();

    public bool switchState = false;

    private AudioSource audioSource;

    private LogicOutput logicOutput;

    private bool lastPress    = false;
    private bool state        = false;
    private bool supressSound = false;
    private bool oneTime      = true;

    private int buttonSound;

    public void Switch()
    {
        if (oneTime)
        {
            oneTime = false;
            state = !state;
            if (state)
            {
                button.transform.Rotate(rotationOffset * -1);

                audioSource.clip = buttonDownSounds[buttonSound];

                audioSource.Play();
            }
            else
            {
                button.transform.Rotate(rotationOffset);

                audioSource.clip = buttonUpSounds[buttonSound];

                audioSource.Play();
            }
            logicOutput.setState(state);
        }
    }

    public void SwitchEnd()
    {
        oneTime = true;
    }

    void Start()
    {
        logicOutput = this.GetComponent<LogicOutput>();
        audioSource = this.GetComponent<AudioSource>();
        buttonSound = Random.Range(0, buttonDownSounds.Count);
        if (switchState)
        {
            button.transform.eulerAngles -= rotationOffset;
            Switch();
            SwitchEnd();
        }
    }
}
