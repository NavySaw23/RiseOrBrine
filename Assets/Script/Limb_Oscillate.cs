using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb_Oscillate : MonoBehaviour
{
    public Manager manager;
    public float factor;
    public float speed;
    public Transform MainBody;


    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.timeIsRunning && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            transform.position = new Vector3(MainBody.position.x + Mathf.Sin(Time.time*speed)* factor, MainBody.position.y, MainBody.position.z);
        }
    }
}
