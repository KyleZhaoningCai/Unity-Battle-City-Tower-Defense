/*
 File Name: PlayerTankBasic.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the behaviour of the player tank GameObject
public class PlayerTankBasic : MonoBehaviour
{
    public int damage;
    public int bulletSpeed;
    public GameObject bullet;
    public GameObject spawnPoint;
    public float cooldown;

    private float originalCooldown;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        originalCooldown = cooldown;
        target = null;
        cooldown = 0;

        // Make trigger collider stay event working even when GameObject is not moving
        GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        // Fire a player bullet when cooldown drops to 0
        cooldown -= Time.deltaTime;
        if (cooldown <= 0 && target != null)
        {
            FireBullet();
            cooldown = originalCooldown;
        }
    }

    // Rotate toward the target, then fires a bullet at the target direction
    private void FireBullet()
    {
        var offset = 270f;
        Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));

        GameObject bulletObject = Instantiate(bullet, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y), transform.rotation);
        bulletObject.GetComponent<PlayerBullet>().SetBulletDamage(damage);
        bulletObject.GetComponent<Rigidbody2D>().velocity = bulletObject.transform.up * bulletSpeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If an enemy is within the trigger collider, if this player tank has no target, set
        // the enemy as the target
        if (collision.CompareTag("Enemy"))
        {
            if (target == null)
            {
                target = collision.gameObject;
            }
        }
    }

    // When a target enemy leaves the trigger collider, enemy is no longer a target 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            target = null;
        }
    }
}
