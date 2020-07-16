using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}

// wird aufgerufen bei Klick auf den How To Play Button
public void HandleHowToPlay()
{
    Debug.Log("HowToPay Button pressed:" + Time.time);
}

// wird aufgerufen bei Klick auf den Quitbutton
public void HandleQuit()
{
    Debug.Log("Quit Button pressed:" + Time.time);
}
}
