/*
 File Name: EnemyBullet.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class handles the behaviour of the enemy bullet GameObject
public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletHit;
    public GameObject explosion;

    private int damage;
    private float selfDestroyTimer;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        selfDestroyTimer = 2;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the bullet after 2 seconds
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
        if (collision.CompareTag("Wall") || collision.CompareTag("Base") || collision.CompareTag("DestroyedBase"))
        {
            // Spawn a bullet hit effect
            Instantiate(bulletHit, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            // Damage the wall and destroy this bullet
            if (collision.CompareTag("Wall"))
            {
                collision.GetComponent<Wall>().DamageWall(damage);
                Destroy(gameObject);
            }

            // When in contact with base GameObject, spawn explosion effect, destroy both this bullet and base,
            // and set the game state to game over, set the values of the DontDestroy GameObject, then load the Result scene
            else if (collision.CompareTag("Base"))
            {
                Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                gameController.gameState = "gameOver";
                gameController.dontDestroyObject.GetComponent<DontDestroyObject>().gameState = gameController.gameState;
                gameController.dontDestroyObject.GetComponent<DontDestroyObject>().coins = gameController.coins;
                SceneManager.LoadScene("Result");
            }
            else if (collision.CompareTag("DestroyedBase"))
            {
                Destroy(gameObject);
            }
        }
    }
}
