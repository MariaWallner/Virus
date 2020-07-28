using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{   
    public Slider slider;
    public Text easy, normal, hard;

    // wird aufgerufen bei Klick auf den Playbutton
    public void HandlePlay()
    {
        Debug.Log("Play Button pressed:" + Time.time);
        SceneManager.LoadScene("Game"); //von einer Scene zu anderen gelangen (von Main zu Game)
    }

    public void HandleBack()
    {
        Debug.Log("Back Button pressed:" + Time.time);
        SceneManager.LoadScene("Main"); //von einer Scene zu anderen gelangen 
    }

    public void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver"); //von einer Scene zu anderen gelangen 
    }

    // wird aufgerufen bei Klick auf den How To Play Button
    public void HandleHowToPlay()
    {
        Debug.Log("HowToPay Button pressed:" + Time.time);
        SceneManager.LoadScene("HowTo"); //von einer Scene zu anderen gelangen 
    }

    // wird aufgerufen bei Klick auf den Quitbutton
    public void HandleQuit()
    {
        Debug.Log("Quit Button pressed:" + Time.time);
        Application.Quit();
    }

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
                    LevelManager.instance.spawnProbability = 0.97f;
                    easy.fontSize = 80;
                    normal.fontSize = 50;
                    hard.fontSize = 50;
                    break;
                case 1:
                    LevelManager.instance.spawnProbability = 0.93f;
                    easy.fontSize = 50;
                    normal.fontSize = 80;
                    hard.fontSize = 50;
                     break;
                case 2:
                    LevelManager.instance.spawnProbability = 0.80f;
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
