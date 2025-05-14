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
            anim.SetTrigger("Jump");
            rb.linearVelocityY = speed;
        }
    }
}
