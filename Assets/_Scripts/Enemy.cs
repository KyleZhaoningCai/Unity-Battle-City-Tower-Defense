using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public int speed;
    public int bulletSpeed;
    public GameObject bulletObject;
    public float fireInterfal = 1;
    public int damage;
    public int hp;

    private GameObject[] waypoints;
    private GameObject finalWaypoint;
    private int waypointIndex;
    private Vector2 currentWaypoint;
    private bool isFiring;
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
        originalFireInterval = fireInterfal;
        fireInterfal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFiring)
        {
            GetComponent<Animator>().speed = 1;
            MoveToPosition(currentWaypoint);
            if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex < waypoints.Length - 1)
            {
                waypointIndex++;
                currentWaypoint = waypoints[waypointIndex].transform.position;
                RotateTowards(currentWaypoint);
            }
            else if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex == waypoints.Length - 1)
            {
                waypointIndex++;
                currentWaypoint = finalWaypoint.transform.position;
                RotateTowards(currentWaypoint);
            }
            else if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex == waypoints.Length)
            {
                isFiring = true;
                RotateTowards(baseObject.transform.position);
            }
        }
        else
        {
            GetComponent<Animator>().speed = 0;
            fireInterfal -= Time.deltaTime;
            if (fireInterfal <= 0)
            {
                FireBullet();
                fireInterfal = originalFireInterval;
            }
        }
    }

    public void SetFinalWaypoint(GameObject finalWaypointGameObject)
    {
        finalWaypoint = finalWaypointGameObject;
    }

    private void MoveToPosition(Vector2 position)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), position, speed * Time.deltaTime);
    }

    // Code from Unity Forum
    private void RotateTowards(Vector2 target)
    {
        var offset = 270f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletObject, new Vector2(bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y), gameObject.transform.rotation);
        bullet.GetComponent<EnemyBullet>().SetBulletDamage(damage);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isFiring = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isFiring = false;
        }
    }
}
