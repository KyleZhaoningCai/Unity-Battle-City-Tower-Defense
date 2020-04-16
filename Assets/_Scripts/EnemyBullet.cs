using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (collision.CompareTag("Wall") || collision.CompareTag("Base") || collision.CompareTag("DestroyedBase"))
        {
            Instantiate(bulletHit, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            if (collision.CompareTag("Wall"))
            {

                collision.GetComponent<Wall>().DamageWall(damage);
                Destroy(gameObject);
            }
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
