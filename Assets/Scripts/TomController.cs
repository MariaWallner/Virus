using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal") * 13f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
