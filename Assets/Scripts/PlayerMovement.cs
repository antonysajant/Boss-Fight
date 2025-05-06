using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpspeed = 2.5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer spriterend;
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        anim.SetFloat("Run", Mathf.Abs(horizontalInput));
        movement();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void movement()
    {
        if (horizontalInput > 0.4)
        {
            spriterend.flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (horizontalInput < -0.4) 
        {
            spriterend.flipX = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            anim.SetBool("Jump", true);
            rb.linearVelocityY = speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Debug.Log("Touched Ground");
            anim.SetBool("Jump", false);
        }

    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
