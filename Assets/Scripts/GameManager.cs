using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawners
{
    public GameObject go;
    public bool active;
    public Spawners(GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel01;
    public delegate void RestartRounds();
    public static event RestartRounds RoundComplete;

    private int health;
    private int roundsSurvived = 1;
    private int currentRound = 1;
    private PlayerDamage playerDamage;
    private Text roundFinished;
    private Text panelText;

    public List<Spawners> spawner = new List<Spawners>( );

    void Start()
    {
        Time.timeScale = 1;
        //panel.SetActive(false);
        playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>();
        // setting my text to a game object so i can set active / not active
        panelText = panel.GetComponentInChildren<Text>();
        roundFinished = panel01.GetComponentInChildren<Text>();
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name.Contains("Spawner"))
            {
                spawner.Add(new Spawners(go, true));
            }
        }
    }

    void Update()
    {   
        

        int total = 0;
        health = playerDamage.health;

        // if the player is still alive / not at 0 health.
        if (health > 0)
        {
            for (int i = spawner.Count - 1; i >= 0; i--)
            {
                if (spawner[i].go.GetComponent<Spawner>().spawnsDead)
                {
                    total++;
                }
            }

            // if all the enemies are dead and the roundsSurvived is the round you are on then it adds one to rounds survived. (go to the next round).
            if (total == spawner.Count && roundsSurvived == currentRound)
            {
                roundsSurvived++;
                panelText.text = string.Format("Round: {0}", roundsSurvived);
                roundFinished.text = string.Format("Press right mouse button to start the next round", roundFinished);
                
                panel.SetActive(true);
                panel01.SetActive(true);
            }
            //when the round is done your click right mouse button to go to the next round
            if (roundsSurvived != currentRound && Input.GetButton("Fire2"))
            {
                currentRound = roundsSurvived;
                //updating the round text
                panelText.text = string.Format("Round: {0}", roundsSurvived);
                //reseting the round.
                RoundComplete();
                // making the press right mouse button text appear
                panel01.SetActive(false);
                //panel.SetActive(false);
            }
        }
        else
        {      
            PauseMenu.GameIsOver = true;
            panel.SetActive(true);
            roundFinished.text = string.Format("You Survived {0} Rounds", roundsSurvived);
            
            
        }
    }
}