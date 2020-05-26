using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{

    public float speed = 1f;
    public float distance = 5f;

    private bool active;

    private Vector3 MovePos;
    private float offset;
    // Update is called once per frame


    public void setActive(bool state)
    {
        active = state;
    }

    private void Start()
    {
        offset = Random.Range(0.5f, 1.5f);
    }


    void Update()
    {
        if (active)
        {
            MovePos = transform.position;
            MovePos.x = Mathf.Sin(Time.time * speed * offset) * distance;
            transform.position = MovePos;
        }
    }
}
