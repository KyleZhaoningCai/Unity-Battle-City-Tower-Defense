using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBag : MonoBehaviour
{

    private float selfDestoyTime;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        selfDestoyTime = 3f;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        selfDestoyTime -= Time.deltaTime;
        if (selfDestoyTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        gameController.GetComponent<AudioSource>().Play();
        gameController.coins += 200;
        Destroy(gameObject);
    }
}
