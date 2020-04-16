using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject explosion;
    public int hp;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SetHp(int wallHp)
    {
        hp = wallHp;
    }

    public void DamageWall(int bulletDamamge)
    {
        hp -= bulletDamamge;
        if (hp <= 0)
        {
            for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
            {
                if (transform.position.x == gameController.wallPlaceholders[i].transform.position.x && transform.position.y == gameController.wallPlaceholders[i].transform.position.y)
                {
                    gameController.hasWall[i] = false;
                    break;
                }
            }
            Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
