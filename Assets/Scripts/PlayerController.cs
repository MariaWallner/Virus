using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject gameOver;
    public float speed = 7f;
    private Rigidbody2D rb;
    private float health = 1.0f;
    public Text healthLabel, scoreLabel;
    private long score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 1.0f;
        healthLabel.text = "Health : 100%";
        score = 0;
        scoreLabel.text = "Score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        gameOver.SetActive(false);
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput, 0) * speed;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
            //1. Schritt: Gesundheitswert aktualisieren
            if (other.collider.name.StartsWith("Virus"))
            {
                health -= 0.25f;
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
            }
            else if (other.collider.name.StartsWith("Desinfektionsmittel"))
            {
                health += 0.2f;
                score += 1000;
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
                //FindObjectOfType<AudioManager>().Play("desinfektionsmittel");
            }
            else if (other.collider.name.StartsWith("Schutzmaske"))
            {
                health += 0.1f;
                score += 200;
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
            }
    
        //2.Schritt: Limits überprüfen:
         if (health <= 0.0f)
        {
            Debug.Log("Game Over");
            gameOver.SetActive(true);
            health = 0.0f;
            StartCoroutine(RemovePlayer());
            gameOver.SetActive(true);

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

        //Objekt einmalig Kraft nach oben und Drehmoment hinzufügen
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
        gameObject.SetActive(false);

    }

}
