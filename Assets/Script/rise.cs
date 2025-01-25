using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rise : MonoBehaviour
{
    public Manager manager;
    public float speed;
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        speed = Random.Range(0.8f, 1.2f);
    }

    void Update()
    {
        if(manager.timeIsRunning && transform.position.y < 22f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else{
            transform.position = new Vector3(transform.position.x, -20f, transform.position.z);
        }
    }
}
