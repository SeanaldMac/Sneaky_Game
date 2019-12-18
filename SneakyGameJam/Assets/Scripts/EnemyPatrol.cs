using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float maxY, minY, speedY;

    Rigidbody2D rb;
    private Vector2 direction;
    public GameObject fov;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(0, speedY);
    }

    
    void Update()
    {
        rb.velocity = direction;

        if (rb.position.y > maxY && rb.velocity.y > 0)
        {
            direction = new Vector2(0, -Mathf.Abs(direction.y));
            rb.velocity = direction;
            fov.GetComponent<Transform>().Rotate(new Vector3(0, 0, 180));
        }
        else if (rb.position.y < minY && rb.velocity.y < 0)
        {
            direction = new Vector2(0, Mathf.Abs(direction.y));
            rb.velocity = direction;
            fov.GetComponent<Transform>().Rotate(new Vector3(0, 0, -180));
        }
    }
}
