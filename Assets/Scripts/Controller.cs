using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Controller : MonoBehaviour
{

    float dirX, dirY;
	Rigidbody2D rb;
    public float speed = 2.5f;
    float maxSpeed = 1.5f;
    bool faceLeft = true;
 
	void Start(){
        rb = GetComponent<Rigidbody2D>();
	}

	void Update() 
	{
		// Player should go up by default. Speed should decay over 5sec
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
	}
    void FixedUpdate() 
    {

        if (dirX < 0 &&!faceLeft)
            Flip ();
        else if (dirX > 0 && faceLeft)
            Flip ();
        

        rb.velocity = new Vector2(dirX * speed, dirY * speed);
    }
    
    void Flip ()
    {
        faceLeft = !faceLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    // void OnTriggerEnter2D(Collider2D other){
    //     print("Do stuff");
    // }


}