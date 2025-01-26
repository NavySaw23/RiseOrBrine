using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public bool timeIsRunning;
    public UIManagement uIManagement;

    public int Life;

    void Start()
    {

        Life = 3;
        timeIsRunning = false;
    }

    void Update()
    {

    }

    public void gameover()
    {
        uIManagement.Gameover();

        Invoke("ReloadScene", 5f);

    }

    public void startTime()
    {
        timeIsRunning = true;
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
