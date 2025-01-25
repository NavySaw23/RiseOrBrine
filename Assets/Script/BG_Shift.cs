using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Shift : MonoBehaviour
{
    public Manager manager;
    public float speed = 0.00003f;
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.timeIsRunning && transform.position.y > -50f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            speed += 0.000001f;
        }
    }
}
