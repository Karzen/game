using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falldown : MonoBehaviour
{
    public Rigidbody rigid;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Ground")
        {
            Debug.Log("Coliziune");
            rigid.useGravity = false;

        }
        
        
    }

}
