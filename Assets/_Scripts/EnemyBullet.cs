﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

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
        if (collision.CompareTag("Wall"))
        {
            collision.GetComponent<Wall>().DamageWall(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Base"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            FindObjectOfType<GameController>().gameState = "gameOver";
        }
        else if (collision.CompareTag("DestroyedBase"))
        {
            Destroy(gameObject);
        }
    }
}
