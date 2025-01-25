using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMovement : MonoBehaviour
{
    public Manager manager;
    public int moveSpeed;
    public bool onPlatform;
    public bool dash;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        dash = false;
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (manager.timeIsRunning)
        {
            movement();
            //if player falls off screen
            if (transform.position.y < -10) { respawn(); }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.tag == "Platform")
        {
            onPlatform = true;
        }
    }


    void movement()
    {
        //movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }





        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && onPlatform)
        {
            onPlatform = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.up * 10;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.down * 40;
        }
    }


    void StopDash()
    {
        dash = false;
    }

    void respawn()
    {
        transform.position = new Vector3(0, 0, 0);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
