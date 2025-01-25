using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool timeIsRunning;

    public int Life;

    void Start()
    {

        Life = 3;
        timeIsRunning = true;
    }

    void Update()
    {

    }

    public void gameover(){ 

    }
}
