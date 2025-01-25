using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_Oscillate : MonoBehaviour
{
    public Manager manager;
    public float speed;
    public bool dir;


    void Start()
    {
        speed = 1f;
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    void Update()
    {
        if (manager.timeIsRunning)
        {
            if(transform.position.x >= 6f)
            {
                dir = false;
            }
            else if(transform.position.x <= -6f)
            {
                dir = true;
            }


            if(dir){
                transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
            else{
                transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
