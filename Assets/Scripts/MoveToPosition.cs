using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    //setting variables
    public float knockbackTime = 1;
    public float kick = 1.8f;
    //goal will be the player
    private Transform goal;
    private NavMeshAgent agent;
    private bool hit;
    private ContactPoint contact;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //maing the goal = the player
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        //set timer to the same knockback in first instance
        timer = knockbackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) {
            //allow physics to be applied
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //Stop ai
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            //knockback our enemy.
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * kick, contact.point, ForceMode.Impulse);
            hit = false;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            //After being knocked back, restart movement
            if (knockbackTime < timer)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                //update destination for enemy
                agent.SetDestination(goal.position);
            }
        }
    }
        
    void OnCollisionEnter(Collision other)
    {
        //We compare the tag in the other object to the tag name we set earlier.
        if (other.transform.CompareTag("bullet"))
        {
            contact = other.contacts[0];
            hit = true;
        }
    }
    
    
}

