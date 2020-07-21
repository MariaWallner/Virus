using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
