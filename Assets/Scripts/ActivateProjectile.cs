using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateProjectile : MonoBehaviour
{

    public GameObject projectile;

    public float ttl = 4.0f;

    public Text ammoPanel;
    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 3f;
    private bool isReloading = false;

    public Animator animator;

    private GameObject clone;


    void Start()
    {
        currentAmmo = maxAmmo;
    }

    //this fixed a bug where the gun would reload instantly but still be able to shoot for the first 30 bullets.
    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        //making sure you cant shoot while in the pause menu
        if (!PauseMenu.GameIsPaused && !PauseMenu.GameIsOver)
        {
            // if its reloading it ends the loop and starts the update again.
            if(isReloading)
                return;
            //if the ammo you have is 0 or less then starts the reload function
            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }
            //if the left mouse button is pressed it creates a projectile and takes one away from current ammo.
            if(Input.GetButtonDown("Fire1")){
                //Debug.log("projectile");
                currentAmmo--;
                ammoPanel.text = string.Format("{0} / 30", currentAmmo);
                clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);

                Destroy(clone, ttl);
            
            }
        }
    }

    // reload function 
    IEnumerator Reload()
    {

        isReloading = true;
        // Debug.Log("Reloading...");
        // animating
        animator.SetBool("Reloading", true);

        //waiting for animation to happen takes reloadTime seconds to reload.
        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);

        // sets ammo back to full.
        currentAmmo = maxAmmo;
        ammoPanel.text = string.Format("{0} / 30", currentAmmo);
        // finishes reloading.
        isReloading = false;
    }
}

