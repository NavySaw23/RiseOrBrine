using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentWeapon;
    void Start()
    {
        currentWeapon = transform.parent.GetComponent<weapon>().currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        currentWeapon = transform.parent.GetComponent<weapon>().currentWeapon;
        if (collision.gameObject.tag == "Enemy" && currentWeapon == 1)
        {
            collision.gameObject.GetComponent<Enemy>().health -= 100;
        }
        if (collision.gameObject.tag == "Enemy" && currentWeapon == 2)
        {
            collision.gameObject.GetComponent<Enemy>().health -= 50;
        }
    }

}
