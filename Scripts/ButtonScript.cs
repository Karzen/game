using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public GameObject button;

    public Vector3 pressOffset;

    public List<AudioClip> buttonDownSounds =  new List<AudioClip>();
    public List<AudioClip> buttonUpSounds = new List<AudioClip>();


    private AudioSource audioSource;

    private LogicOutput logicOutput;

    private bool lastPress = false;

    private int buttonSound;

    public void pressButton(bool press)
    {

        if (press && press != lastPress)
        {  
            lastPress = press;

            button.transform.position = button.transform.position - pressOffset;

            audioSource.clip = buttonDownSounds[buttonSound];

            audioSource.Play();
        }
        else if(press != lastPress)
        {
            lastPress = press;

            button.transform.position = button.transform.position + pressOffset;

            audioSource.clip = buttonUpSounds[buttonSound];

            audioSource.Play();
        }

        Debug.Log(press + "nigga");
        logicOutput.setState(press);
    }


    void Start()
    {
        logicOutput = this.GetComponent<LogicOutput>();
        audioSource = this.GetComponent<AudioSource>();
        buttonSound = Random.Range(0, buttonDownSounds.Count);
    }
 


}
