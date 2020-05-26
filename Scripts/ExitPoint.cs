using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    public Light point;

    public bool enabled = false;

    public void setEnabled(bool state)
    {
        enabled = state;

        point.enabled = state;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && enabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Start()
    {
        point.enabled = enabled;
    }




}
