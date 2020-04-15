using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0 && target != null)
        {
            FireBullet();
            cooldown = originalCooldown;
        }
    }

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
        if (collision.CompareTag("Enemy"))
        {
            if (target == null)
            {
                target = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            target = null;
        }
    }
}
