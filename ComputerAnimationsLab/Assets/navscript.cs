using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navscript : MonoBehaviour
{

    public GameObject theTarget;
    public NavMeshAgent theAgent;
    bool isWalking = true;


    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        theAgent.destination = theTarget.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dragon")
        {
            animator.SetTrigger("ATTACK");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            animator.SetTrigger("WALK");
        }
    }
}
