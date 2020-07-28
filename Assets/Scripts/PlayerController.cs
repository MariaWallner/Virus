﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 30f;
    private Rigidbody2D rb;
    private float health = 1.0f;
    public Text healthLabel, scoreLabel;
    private long score;
    public MenuHandler menuHandler;
    public Animator animator;
    public SpriteRenderer sprite;

    void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
         if (animator != null) 
                {
                    animator.SetBool("isHappy", true);
                    animator.SetBool("isCatching", true);
                    animator.SetFloat("health", 1.0f);
                }
    }


    //void OnEnable()


    // Start is called before the first frame update
    void Start()
    {
        health = 1.0f;
        healthLabel.text = "Health : 100%";
        score = 0;
        scoreLabel.text = "Score : 0";
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput, 0) * speed * Time.fixedDeltaTime; //fixedDeltaTime = Zeitspanne, die zwischen 2 physikalischen Updates liegen
    }

    // Update is called once per frame
    void Update()
    {
        //gameOver.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
            //1. Schritt: Gesundheitswert aktualisieren
            if (other.collider.name.StartsWith("Virus"))
            {
                health -= 0.25f;

                if (animator != null) 
                {
                    animator.SetBool("isHappy", false);
                    animator.SetBool("isCatching", false);
                }

                //gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
            }
            else if (other.collider.name.StartsWith("Desinfektionsmittel"))
            {
                health += 0.2f;
                score += 1000;

                if (animator != null) 
                {
                    animator.SetBool("isHappy", true);
                    animator.SetBool("isCatching", false);
                }

                //gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
                //FindObjectOfType<AudioManager>().Play("desinfektionsmittel");
            }
            else if (other.collider.name.StartsWith("Schutzmaske"))
            {
                health += 0.1f;
                score += 200;

                 if (animator != null) 
                {
                    animator.SetBool("isHappy", true);
                    animator.SetBool("isCatching", false);
                }
                //sprite.color = Color.Lerp(Color.green, Color.white, health);
                //gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
            }
    
        //2.Schritt: Limits überprüfen:
         if (health <= 0.0f)
        {
            Debug.Log("Game Over");
            health = 0.0f;

            if (animator != null) 
                {
                    animator.SetFloat("health", 0f);
                }
            LevelManager.instance.score = score;
            StartCoroutine(RemovePlayer());


        }
        else if (health > 1.0f)
        {
                health = 1.0f;
        }

        //3.Schritt: Gesundheit und Score anzeigen:
        healthLabel.text = "Health : " + Mathf.RoundToInt(health * 100) + "%";
        scoreLabel.text = "Score : " + score;
    }

    IEnumerator RemovePlayer(){
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SliderJoint2D>().enabled = false;

       /* //Objekt einmalig Kraft nach oben und Drehmoment hinzufügen
        rb.AddForce(Vector2.up * 7.6f, ForceMode2D.Impulse);
        rb.AddTorque(7.6f, ForceMode2D.Impulse);

        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        Color c = renderer.color;
        for (float ft = 1f; ft>0; ft -= 0.02f)
        {
            transform.localScale = new Vector3(transform.localScale.x*1.1f, transform.localScale.y*1.1f,1);
            c.a = ft;
            renderer.color = c;
            yield return null;
        }
    */
        yield return new WaitForSeconds (1f);
        menuHandler.HandleGameOver();
    }
    
    //GameOver bei Exit erzwingen
    public void HandleExit()
    {
        LevelManager.instance.score = score;
        menuHandler.HandleGameOver();
    }
}
