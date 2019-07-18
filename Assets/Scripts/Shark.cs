using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{

    bool faceLeft = true;
    public float speed = 2.5f;
    public GameObject UI;
    float dirX;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UI = GameObject.Find("GameManager");
        dirX = 1;
    }


    void FixedUpdate() 
    {
        if (dirX < 0 && faceLeft)
            Flip ();
        else if (dirX > 0 && !faceLeft)
            Flip ();
        
        rb.velocity = new Vector2(dirX * speed, 0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        dirX = dirX * -1;

        if (col.collider.CompareTag("Player")) {
            UI.GetComponent<GameManage>().LifeLost();
        }
        Debug.Log("OnCollisionEnter2D");
    }


    void Flip ()
    {
        faceLeft = !faceLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
