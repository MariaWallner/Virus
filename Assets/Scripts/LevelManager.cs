using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public int currentLevel;

    // Singleton 
    public static LevelManager instance = null;

    //implementation des Singletons:
    void Awake()
    {
        if (instance == null) 
        {instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }





    public GameObject[] prefabs;
    // Start is called before the first frame update
    public float spawnProbability = 0.97f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > spawnProbability)
        {
            // neues Objekt Spawnen:
            GameObject clone = Instantiate(
                prefabs[Random.Range(0, prefabs.Length - 1)],
                new Vector3(Random.Range(-8, 8), 6, 0),
                prefabs[0].transform.rotation);

            float scale = Random.Range(0.5f, 1.5f);
            clone.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
