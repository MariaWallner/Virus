using System.Collections;
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
            animator.SetInteger ("mood", 0);
            animator.SetFloat("health", 1.0f);
        }
    }

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

    public void OnCollisionEnter2D(Collision2D other)
    {
            //1. Schritt: Gesundheitswert aktualisieren
            if (other.collider.name.StartsWith("Virus"))
            {
                health -= 0.25f;

                if (animator != null) 
                {
                    animator.SetInteger ("mood", -1);
                }

            }
            else if (other.collider.name.StartsWith("Desinfektionsmittel"))
            {
                health += 0.2f;
                score += 1000;

                if (animator != null) 
                {
                    animator.SetInteger ("mood", 1);
                }
            }
            else if (other.collider.name.StartsWith("Schutzmaske"))
            {
                health += 0.1f;
                score += 200;

                 if (animator != null) 
                 {
                   animator.SetInteger ("mood", 1);
                 }
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

		AudioManager.instance.Play("gameover"); //PLAY gameover sound

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
