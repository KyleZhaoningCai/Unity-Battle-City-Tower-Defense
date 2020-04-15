using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        selfDestroyTimer -= Time.deltaTime;
        if (selfDestroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetBulletDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(bulletHit, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            collision.GetComponent<Enemy>().ReduceHp(damage);
            Destroy(gameObject);
        }
    }
}
