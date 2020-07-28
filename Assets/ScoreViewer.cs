using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    private Text score;

    void Awake()
    {
        score = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        score.text = "SCORE : " + LevelManager.instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
