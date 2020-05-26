using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class MovePlayer : MonoBehaviour
{
    
    public Camera cam;
    public NavMeshAgent agent;
    public Animator CharacterAnimator;
    public ThirdPersonCharacter character;
    public Transform pickupAttach;
    public PressurePlate pressurePlate;

    public float pickupDistance   = 1f;

    public Vector3 pickupLocation = new Vector3(0f, 0.2f, 0.4f);
    public Vector3 pickupRotation = new Vector3(8f, 165f, 0f);

    private bool letDown  = false;
    private bool pickup   = false;
    private bool holdBox  = false;
    private bool valve    = false;

    private float pickupSize = 0f;

    private RaycastHit hit;

    private GameObject box         = null;
    private GameObject interactive = null;

    private GameObject clickInteractive = null;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        agent = this.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag.Equals("Button"))
                {
                    clickInteractive = hit.collider.gameObject;
                    if(clickInteractive.GetComponent<ButtonScript>())
                        clickInteractive.GetComponent<ButtonScript>().pressButton(true);
                }
                else if (hit.collider.gameObject.tag.Equals("Switch"))
                {
                    clickInteractive = hit.collider.gameObject;
                    if (clickInteractive.GetComponent<SwitchScript>())
                        clickInteractive.GetComponent<SwitchScript>().Switch();
                }
                else
                {
                    if (agent.CalculatePath(hit.point, new NavMeshPath())) {
                        Debug.Log("Haidaaaa");
                        valve = false;
                        agent.SetDestination(hit.point);
                        letDown = false;
                    }    
                }
            }    
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (agent.CalculatePath(hit.point, new NavMeshPath()))
                    agent.SetDestination(hit.point);

                if (hit.collider.gameObject.tag == "Box" && !pickup && agent.CalculatePath(hit.point, new NavMeshPath()))
                {
                    valve = false;
                    pickup = true;
                    letDown = false;
                    box = hit.collider.gameObject;
                }
                else if (hit.collider.gameObject.tag.Equals("Valve"))
                {
                    Debug.Log("Valve Clicked");
                    agent.SetDestination(hit.point);
                    valve = true;
                    interactive = hit.collider.gameObject;
                }
                else if (holdBox && agent.CalculatePath(hit.point, new NavMeshPath()))
                {
                    valve = false;
                    letDown = true;
                    pickup = false;
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if (clickInteractive != null)
            {
                if (clickInteractive.GetComponent<ButtonScript>())
                    clickInteractive.GetComponent<ButtonScript>().pressButton(false);
                else if (clickInteractive.GetComponent<SwitchScript>())
                    clickInteractive.GetComponent<SwitchScript>().SwitchEnd();
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);    
        }
        else
        {
            character.Move(Vector3.zero, false, false);  
        }
        ///===========================PICK UP CRATE=============================================
        if (Vector3.Distance(transform.position, hit.point) <= pickupDistance && pickup && hit.collider.gameObject.tag == "Box")
        { 
            holdBox = true;
            CharacterAnimator.SetBool("Carry", true);
            box = hit.collider.gameObject;
            hit.collider.gameObject.transform.SetParent(pickupAttach);
            hit.collider.enabled = false;
            box.transform.localPosition = pickupLocation; 
            box.transform.localRotation = Quaternion.Euler(pickupRotation);
            box.GetComponent<Rigidbody>().isKinematic = true;
            pickupSize = box.transform.localScale.x;

            if(pressurePlate != null)
                pressurePlate.colisions.Remove(box);
        }
        ///===========================PUT DOWN CRATE=============================================
        
        if (Vector3.Distance(transform.position, hit.point) <= pickupDistance + pickupSize && letDown && holdBox)
        {
            holdBox = false;
            CharacterAnimator.SetBool("Carry", false);
            box.transform.SetParent(null);
            box.GetComponent<BoxCollider>().enabled = true;
            box.GetComponent<Rigidbody>().isKinematic = false;
            letDown = false;
        }

        if(Vector3.Distance(transform.position, hit.point) <= pickupDistance && valve)
        {
            Debug.Log("Valve Interact");
            interactive.GetComponent<Valve>().Interact();
            valve = false;
        }
    }
}
