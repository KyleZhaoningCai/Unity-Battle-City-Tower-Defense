using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLogo : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 0.1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
        }
    }
}
