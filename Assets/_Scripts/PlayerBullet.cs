/*
 File Name: PlayerBullet.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the player bullet GameObject
public class PlayerBullet : MonoBehaviour
{
    public GameObject bulletHit;
    public GameObject explosion;

    private int damage;
    private float selfDestroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        selfDestroyTimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy this bullet after 2 seconds
        selfDestroyTimer -= Time.deltaTime;
        if (selfDestroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Set the damage of this bullet
    public void SetBulletDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When in touch with an enemy GameObject, spawn bullet hit effect, reduce enemy HP, then destroy this bullet
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(bulletHit, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            collision.GetComponent<Enemy>().ReduceHp(damage);
            Destroy(gameObject);
        }
    }
}
