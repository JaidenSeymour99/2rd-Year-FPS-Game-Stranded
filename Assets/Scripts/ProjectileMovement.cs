using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    //speed of our bullet (changable)
    public float speed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        //moving the bullet in a direction and with x speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}