using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateLevel : MonoBehaviour
{

    public GameObject player;
    public GameObject wall;
    public NavMeshSurface NavSurf;

    public Vector3 InitialPosition;

    
    

    // Start is called before the first frame update
    void Start()
    {
        Generate();
        NavSurf.BuildNavMesh();
        transform.position = new Vector3(0f, 0f, 100f);
        
    }


    

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, InitialPosition, 0.1f);
        if (transform.position.z <= 0.001f)
        {
            this.enabled = false;
        }
    }



    private void Generate()
    {
        bool spawnedPlayer = false;


        for(float i = -10f; i <= 10f; i += 2f)
        {
            for (float j = -10f; j <= 10f; j += 2f)
            {
                if(Random.value > 0.65f)
                {
                    Instantiate(wall, new Vector3(i, 1f, j), Quaternion.identity, transform);
                }
                else if (!spawnedPlayer){

                    Instantiate(player, new Vector3(i, 1f, j), Quaternion.identity);
                    spawnedPlayer = true;
                }
                
            }
        }



    }

}
