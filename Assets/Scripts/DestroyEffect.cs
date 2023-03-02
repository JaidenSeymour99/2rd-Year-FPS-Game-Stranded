using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    
        public float maxTime = 1;
        private float timer;
 

    
    void Update()
    {
        // making the timer not go up each time there is a frame in the update scene
        timer += Time.deltaTime;
        
        //if the timer is greater than the max time set it will destroy the object
        if(timer > maxTime) {
            Destroy(gameObject);
        }
    }
}
