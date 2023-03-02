using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // this number cna be changed for different enemies, to have stronger enemies.
    public int deathNumber = 3;
    //private cant be seen outside this script.
    private int hitNumber;

    private void  OnEnable() {
        //the hit number is the amount of times it has been hit, so it starts at 0.
        hitNumber = 0;
    }

    //Unity stores the collider it hits and we can access it via the name other.
    void OnCollisionEnter(Collision other)
    {   
        // Debug.Log("Collision");
        
        //We compare the tag in the other object to the tag name we set earlier.
        if (other.transform.CompareTag("bullet"))
        {
            //If the comparison is true, we increase the hit number.
            // if its hit by the bullet.
            hitNumber++;
            // Debug.Log(hitNumber);
        }
        //if the hit number is equal to deathNumber we destroy this object.
        if (hitNumber == deathNumber)
        {
            gameObject.SetActive(false); 
            // Destroy(gameObject);
        }
    }
}
