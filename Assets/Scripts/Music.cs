using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource musicAudio;
    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Music");
        // if it sees the second instance of the object it destroys the new music
        if(objects.Length > 1)
            Destroy(this.gameObject);
        //keeps the first music not destroyed
        DontDestroyOnLoad(this.gameObject);
    }
}
