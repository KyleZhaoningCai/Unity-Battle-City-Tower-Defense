using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        destroyTimer = 0.25f;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
