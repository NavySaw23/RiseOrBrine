using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public Manager manager;

    public GameObject pause, play, exit, h1, h2, h3, gameover;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        h1.SetActive(true);
        h2.SetActive(true);
        h3.SetActive(true);
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (manager.Life == 2) h3.SetActive(false);
        if (manager.Life == 1) h2.SetActive(false);
        if (manager.Life == 0) h1.SetActive(false);

        if (manager.timeIsRunning)
        {
            play.SetActive(false);
            exit.SetActive(false);
        }
        else if (manager.timeIsRunning == false)
        {
            play.SetActive(true);
            exit.SetActive(true);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        manager.timeIsRunning = false;
    }

    public void Play()
    {
        manager.timeIsRunning = true;
    }


    public void Gameover()
    {
        Debug.Log("UI function");
        gameover.SetActive(true);
    }
}