using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Manager manager;
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
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

    }

    void enemyDeath()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<charMovement>().respawn();
        }
    }
}
