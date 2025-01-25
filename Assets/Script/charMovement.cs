using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class charMovement : MonoBehaviour
{
    public Manager manager;
    public weapon MyWeapon;
    public int moveSpeed;
    public bool onPlatform;
    public bool lookLeft;



    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        MyWeapon = GameObject.Find("Weapon").GetComponent<weapon>();
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (manager.timeIsRunning)
        {
            movement();

            if (Input.GetKeyDown(KeyCode.Z))
            {
                MyWeapon.attack();
            }


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


    void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("Weapon Pickup");

        if (other.gameObject.tag == "WeaponPickup")
        {
            Debug.Log("Weapon Pickup");
            MyWeapon.changeWeapon(1);
            Destroy(other.gameObject);
        }
    }


    void movement()
    {
        //movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (lookLeft == false)
            {
                transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                lookLeft = true;
            }
        }


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (lookLeft == true)
            {
                transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                lookLeft = false;
            }
        }





        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && onPlatform)
        {
            onPlatform = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.up * 10;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.down * 40;
        }
    }



    public void respawn()
    {
        if (manager.Life > 0)
        {
            manager.Life--;
            transform.position = new Vector3(0, 0, 0); 
            
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else
        {
            Destroy(gameObject);
            manager.gameover();
            manager.timeIsRunning = false;
        }
    }

    



}
