using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public int StartPosition = 0;
    public int NumberOfPositions = 4;


    public Vector3[] positions =
    {
        new Vector3(-11.55f, 10.92f, -11.55f),
        new Vector3(11.55f, 10.92f, -11.55f),
        new Vector3(11.55f, 10.92f, 11.55f),
        new Vector3(-11.55f, 10.92f, 11.55f),
    };

    public Vector3[] angles =
   {
        new Vector3(35f, 45f, 0f),
        new Vector3(35f, -45f, 0f),
        new Vector3(35f, -135f, 0f),
        new Vector3(35f, -225f, 0f),
    };

    private Vector3 iniAngle;


    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, positions[StartPosition], 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angles[StartPosition]), 0.1f);

        if (Input.GetKeyDown("q"))
        {
            StartPosition--;
            if(StartPosition < 0)
            {
                StartPosition = NumberOfPositions - 1;
            } 
        }
        else if (Input.GetKeyDown("e"))
        {
            StartPosition++;
            if (StartPosition == NumberOfPositions)
            {
                StartPosition = 0;
            }        
        }


    }
}
