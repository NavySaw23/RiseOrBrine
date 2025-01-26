using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource EnemyDeath;
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
            EnemyDeath.Play();
            collision.gameObject.GetComponent<Enemy>().health -= 100;
        }
    }

}
