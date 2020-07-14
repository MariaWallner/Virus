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
    public Text healthLabel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 1.0f;
        healthLabel.text = "Health : 100%";

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
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
                //FindObjectOfType<AudioManager>().Play("desinfektionsmittel");
            }
            else if (other.collider.name.StartsWith("Schutzmaske"))
            {
                health += 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, health);
            }
    
        //2.Schritt: Limits überprüfen:
         if (health <= 0.0f)
        {
            Debug.Log("Game Over");
            health = 0.0f;
            
            gameOver.SetActive(true);
            
            gameObject.SetActive(false);

        }
        else if (health > 1.0f)
        {
                health = 1.0f;
        }

        //3.Schritt: Gesundheit anzeigen:
        healthLabel.text = "Health : " + Mathf.RoundToInt(health * 100) + "%";
    }
}
