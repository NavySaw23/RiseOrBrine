using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Manager manager;
    public float health = 100f;
    public bool enemyAI = false;
    public charMovement player;

    public float delX;
    public float delY;

    public bool jumpable = false;

    public float lastHitTime = 0;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        player = GameObject.Find("Character").GetComponent<charMovement>();
        lastHitTime = Time.time-5f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (health <= 0) { enemyDeath(); }

        transform.GetChild(1).localScale = new Vector3(
            Math.Abs(Mathf.Sin(Time.time) * 0.05f) + 0.15f,
            Math.Abs(Mathf.Sin(Time.time) * 0.05f) + 0.15f,
            Math.Abs(Mathf.Sin(Time.time) * 0.05f) + 0.15f
        );

        if (transform.position.y < 6) { enemyAI = true; }
        else if (transform.position.y > 8) { enemyAI = false; }

        delX = player.transform.position.x - transform.position.x;
        delY = player.transform.position.y - transform.position.y;

        if (enemyAI)
        {
            if (delX > 1)
            {
                transform.position += new Vector3(0.005f, 0, 0);
            }
            else if (delX < -1)
            {
                transform.position += new Vector3(-0.005f, 0, 0);
            }

            if (delY > 1 && jumpable)
            {
                transform.position += new Vector3(0, 0.007f, 0);
                jumpable = false;
            }
            else if (delY < -1)
            {
                transform.position += new Vector3(0, -0.005f, 0);
            }
        }


        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void enemyDeath()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time > lastHitTime + 5f)
        {
            collision.gameObject.transform.position = new Vector3(100, 0, 0);
            lastHitTime = Time.time;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            jumpable = true;
        }
        else
        {
            jumpable = false;
        }
    }
}
