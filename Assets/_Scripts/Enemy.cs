/*
 File Name: Enemy.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the behaviour of the enemy tank
public class Enemy : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public float speed;
    public float bulletSpeed;
    public GameObject bulletObject;
    public float fireInterval = 1;
    public int damage;
    public int hp;
    public GameObject explosion;
    public int bounty;

    private GameObject[] waypoints;
    private GameObject finalWaypoint;
    private int waypointIndex;
    private Vector2 currentWaypoint;
    private bool isFiring;
    private bool isStopped;
    private GameObject baseObject;
    private GameObject target;
    private float originalFireInterval;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        waypoints = gameController.waypoints;
        baseObject = gameController.baseObject;
        waypointIndex = 0;
        currentWaypoint = waypoints[waypointIndex].transform.position;
        RotateTowards(currentWaypoint);
        isFiring = false;
        isStopped = false;
        originalFireInterval = fireInterval;
        fireInterval = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy is not firing and is moving
        if (!isFiring && !isStopped)
        {
            fireInterval = 0; // Remove firing cooldown
            GetComponent<Animator>().speed = 1; // Moving animation
            MoveToPosition(currentWaypoint);

            // If reached the target location and the next target is not the final location
            if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex < waypoints.Length - 1)
            {
                waypointIndex++;
                currentWaypoint = waypoints[waypointIndex].transform.position; // Set new target location
                RotateTowards(currentWaypoint);
            }

            // If reached the target location and the next target is the final location
            else if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex == waypoints.Length - 1)
            {
                waypointIndex++;
                currentWaypoint = finalWaypoint.transform.position;
                RotateTowards(currentWaypoint);
            }

            // If reached the final location, start firing at the player base
            else if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex == waypoints.Length)
            {
                // Check if the animator has a parameter, only boss enemy has this parameter to control flashing
                if (GetComponent<Animator>().parameterCount > 0)
                {
                    // Set animation to no movement but still flashing
                    GetComponent<Animator>().SetInteger("tankState", 1);
                }

                // Destroy the GameObject that has a trigger collider to stop other enemies
                Destroy(transform.GetChild(1).gameObject);
                isFiring = true;
                RotateTowards(baseObject.transform.position);
            }
        }

        // If the enemy is firing or has stopped
        else if (isFiring || isStopped)
        {
            if (GetComponent<Animator>().parameterCount == 0)
            {
                // Set animation speed to 0 to stop animation
                GetComponent<Animator>().speed = 0;
            }
            if (isFiring)
            {
                fireInterval -= Time.deltaTime;

                // If fire interval is equal or less than 0, fire a bullet and reset fire interval
                if (fireInterval <= 0)
                {
                    FireBullet();
                    fireInterval = originalFireInterval;
                }
            }
        }
    }

    // Set the final location of this enemy tank
    public void SetFinalWaypoint(GameObject finalWaypointGameObject)
    {
        finalWaypoint = finalWaypointGameObject;
    }

    // Reduce this enemy's HP by an amount
    public void ReduceHp(int damageDealt)
    {
        hp -= damageDealt;

        // When this enemy has no HP left, gives the player coins and destroy this enemy
        if (hp <= 0)
        {
            gameController.coins += bounty;
            Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Move this enemy to a target location
    private void MoveToPosition(Vector2 position)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), position, speed * Time.deltaTime);
    }

    // Code from Unity Forum to rotate toward a target location
    private void RotateTowards(Vector2 target)
    {
        var offset = 270f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    // Fire a EnemyBullet GameObject at the target direction
    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletObject, new Vector2(bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y), gameObject.transform.rotation);
        bullet.GetComponent<EnemyBullet>().SetBulletDamage(damage);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Start firing at Wall GameObject when in the wall firing range
        if (collision.CompareTag("WallRange"))
        {
            if (GetComponent<Animator>().parameterCount > 0)
            {
                GetComponent<Animator>().SetInteger("tankState", 1);
            }
            RotateTowards(collision.transform.position);
            isFiring = true;
        }

        // Stop if entered another enemy's range to prevent running into it
        else if (collision.CompareTag("EnemyRange"))
        {
            isStopped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Upon leaving the wall firing range
        if (collision.CompareTag("WallRange"))
        {
            if (GetComponent<Animator>().parameterCount > 0)
            {
                // Set animation to moving and flashing
                GetComponent<Animator>().SetInteger("tankState", 0);
            }
            isFiring = false;
        }

        // Upon leaving another enemy's range, start moving again
        else if (collision.CompareTag("EnemyRange"))
        {
            isStopped = false;
        }
    }
}
