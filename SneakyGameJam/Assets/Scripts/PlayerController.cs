using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed, sneakSpeed;
    public bool gameover = false, win = false;

    private Rigidbody2D rb;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveH, moveV);

        if (Input.GetButton("Sneak"))
            rb.velocity = move * sneakSpeed;
        else
            rb.velocity = move * walkSpeed;



        Vector2 moveDirection = rb.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }







}
