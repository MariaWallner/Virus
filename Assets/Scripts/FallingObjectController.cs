using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{   
    //Score als Pfrefab für fallende zahl
    public GameObject scorePrefab;
    public bool isRotating = true;
    public bool isScaling = true;
    // Winkelgeschwindigkeit
    public bool isShifting = true;

    private float timeShift;
    private float angularVelocity;
    // Start is called before the first frame update
    private Vector3 initialScale;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        angularVelocity = Random.Range(20, 45) * Mathf.Sign(Random.Range(-1, 1));
        initialScale = transform.localScale;
        timeShift = Random.Range(0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation:
        if (isRotating)
        {
            rb.angularVelocity = angularVelocity;
        }
        // Wabereffekt:
        if (isScaling)
        {
            transform.localScale = new Vector3(initialScale.x + 0.1f * Mathf.Sin(timeShift + Time.time * 10),
                    initialScale.y + 0.1f * Mathf.Cos(timeShift + Time.time * 10), 1);
        }
        // Schwebeeffekt:
        if (isShifting)
        {
            rb.velocity = new Vector2(2f * Mathf.Sin(timeShift + Time.time * 10), rb.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision : " + gameObject.name + " / " + other.collider.name);
        if (gameObject.name.StartsWith("Virus"))
        {
            if (other.collider.name.StartsWith("Floor"))
            {
                Destroy(gameObject);
            }
            else if (other.collider.name.StartsWith("Player"))
            {
                FindObjectOfType<AudioManager>().Play("virus");
                StartCoroutine(DestroyVirus());
            }
        }
        else if (gameObject.name.StartsWith("Desinfektion") || gameObject.name.StartsWith("Schutzmaske")) 
        {
            if (other.collider.name.StartsWith("Floor"))
            {
                Destroy(gameObject);
            }
            else if (other.collider.name.StartsWith("Player"))
            {
                if (gameObject.name.StartsWith("Desinfektion"))
                {
                    FindObjectOfType<AudioManager>().Play("desinfektionsmittel");   
                }
                else if (gameObject.name.StartsWith("Schutzmaske"))
                {
                    FindObjectOfType<AudioManager>().Play("schutzmaske");
                }
                StartCoroutine(SpawnScore());
                StartCoroutine(DestroyItem());
            }
        }
    }
    //Erzeugt an der Position der Kollision ein animierten Score
    IEnumerator SpawnScore()
    {
        //Spawn Score-Sprite
        //Quaternion = Rotation, Position bisschen über spieler
        GameObject score = Instantiate(scorePrefab, transform.position + Vector3.up*0.5f, Quaternion.identity);
        //Score animieren
        float scale;
        for(scale = 1f; scale < 3; scale += 0.2f)
        {
            score.transform.localScale= new Vector3(scale,scale,1);
            yield return null;
        }

        //Score ausfaden
        SpriteRenderer renderer = score.GetComponent<SpriteRenderer>();
        Color c = renderer.color;
        for (float ft = 1f; ft>0; ft -= 0.02f)
        {
            c.a = ft;
            renderer.color = c;
            yield return null;
        }

        Destroy(score);
    }

    IEnumerator DestroyItem(){
        isScaling = false;
        isShifting = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;

        Color c = renderer.color;
        for (float ft = 1f; ft>0; ft -= 0.05f)
        {
            transform.localScale = new Vector3(transform.localScale.x*1.1f, transform.localScale.y*1.1f,1);
            c.a = ft;
            renderer.color = c;
            yield return null;
        }
           Destroy(gameObject);
    }

    IEnumerator DestroyVirus(){
        isScaling = false;
        isShifting = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;

        Color c = renderer.color;
        for (float ft = 1f; ft>0; ft -= 0.05f)
        {
            transform.localScale = new Vector3(transform.localScale.x*1.1f, transform.localScale.y*1.1f,1);
            c.a = ft;
            renderer.color = c;
            yield return null;
        }
           Destroy(gameObject);
    }

}
