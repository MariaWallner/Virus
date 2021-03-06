﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{   
    public Slider slider;
    public Text easy, normal, hard;


    void Start()
    {
        if (slider != null)
        {
            slider.value = (float) LevelManager.instance.currentLevel;
            HandleLevel();
        }
    }
    

    // wird aufgerufen bei Klick auf den Playbutton
    public void HandlePlay()
    {
        Debug.Log("Play Button pressed:" + Time.time);
        SceneManager.LoadScene("Game"); //von einer Scene zu anderen gelangen (von Main zu Game)
    }

    // wird aufgerufen bei Klick auf den Backbutton 
    public void HandleBack()
    {
        Debug.Log("Back Button pressed:" + Time.time);
        SceneManager.LoadScene("Main"); //von einer Scene zu anderen gelangen (How to zu Main)
    }

    public void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver"); //von einer Scene zu anderen gelangen 
    }

    // wird aufgerufen bei Klick auf den How To Play Button
    public void HandleHowToPlay()
    {
        Debug.Log("HowToPay Button pressed:" + Time.time);
        SceneManager.LoadScene("HowTo"); //von einer Scene zu anderen gelangen (Main zu How to)
    }

    // wird aufgerufen bei Klick auf den Quitbutton (Main wird beendet/Spiel verlassen)
    public void HandleQuit()
    {
        Debug.Log("Quit Button pressed:" + Time.time);
        Application.Quit();
    }

    //
    public void HandleLevel()
    {
        if (slider != null)
        {
            int value = (int) slider.value;
            LevelManager.instance.currentLevel = value;
            Debug.Log(Time.time + "value = " + value);

            switch (value)
            {
                case 0:
                    LevelManager.instance.spawnProbability = 0.98f;
                    easy.fontSize = 80;
                    normal.fontSize = 50;
                    hard.fontSize = 50;
                    break;
                case 1:
                    LevelManager.instance.spawnProbability = 0.96f;
                    easy.fontSize = 50;
                    normal.fontSize = 80;
                    hard.fontSize = 50;
                     break;
                case 2:
                    LevelManager.instance.spawnProbability = 0.94f;
                    easy.fontSize = 50;
                    normal.fontSize = 50;
                    hard.fontSize = 80;
                     break;
                default:
                    LevelManager.instance.spawnProbability = 0.97f;
                    easy.fontSize = 80;
                    normal.fontSize = 50;
                    hard.fontSize = 50;
                     break;
            }
        }
    }
}
