using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float velocidade = 5f;
    Rigidbody2D rb;
    Vector2 movement;
    Animator anim;
    SpriteRenderer render;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Void para controles
        movement.x = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            anim.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
            velocidade = 9;
        }
        else
        {
            anim.SetBool("Run", false);
            velocidade = 5f;
        }
    }

    private void FixedUpdate()
    {
        //Void para movimento
        rb.MovePosition(rb.position + movement * velocidade * Time.fixedDeltaTime);
    }

}