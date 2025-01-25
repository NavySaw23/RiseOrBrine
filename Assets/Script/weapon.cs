using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class weapon : MonoBehaviour
{
    public Manager manager;
    public charMovement player;
    public int currentWeapon;

    public Sprite Empty, Thumb, Staple, Fan;
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        player = GameObject.Find("Character").GetComponent<charMovement>();
        changeWeapon(1);
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeWeapon(int w)
    {
        switch (w)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = Empty;
                currentWeapon = 0;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = Thumb;
                currentWeapon = 1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = Staple;
                currentWeapon = 2;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = Fan;
                currentWeapon = 3;
                break;
        }
    }

    public void attack()
    {
        switch (currentWeapon)
        {
            case 0:
                break;
            case 1:
                transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
                if (player.lookLeft) transform.position += new Vector3(-0.5f, 0, 0);
                else transform.position += new Vector3(0.5f, 0, 0);
                Invoke("ResetAOEPosition", 0.5f);

                break;
            default:
                Invoke("ResetAOEPosition", 0.5f);
                break;

        }
    }

    public void ResetAOEPosition()
    {
        if (player.lookLeft)
            transform.position = transform.parent.position + new Vector3(-0.5f, 0, 0);
        else
            transform.position = transform.parent.position + new Vector3(0.5f, 0, 0);

        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;

    }

}
