using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moving_speed;
    public float movingSpeed 
    {
        get => _moving_speed;
        
        set => _moving_speed = value;
    }

    [SerializeField] float jump_force;
    [SerializeField] LayerMask Environment;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CapsuleCollider2D capsule_collider;
    [SerializeField] Animator animator;
    private float horizontal_direction;
    [SerializeField] Transform player_body;
    bool facing_right = true;
    bool pressed_space = false;
    bool has_been_killed { get; set;}

    void Update()
    {
        animator.SetFloat("Speed", System.Math.Abs(horizontal_direction));
        horizontal_direction = Input.GetAxis("Horizontal");

        if (horizontal_direction > 0 && !facing_right)
            flip_character();

        else if (horizontal_direction < 0 && facing_right) 
            flip_character();

        if (Input.GetKeyDown(KeyCode.Space))
            pressed_space = true;
    }

    void FixedUpdate()
    {
        jump();
        move(horizontal_direction);
    }

    void flip_character() 
    {
        facing_right = !facing_right;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void jump()
    {
        if (pressed_space && on_ground())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
            pressed_space = false;
        }
        bool on_ground()
        {
            float raycast_size = .1f;
            RaycastHit2D box_ray = Physics2D.BoxCast(capsule_collider.bounds.center, capsule_collider.bounds.size, 0f, Vector2.down, raycast_size, Environment);
            return box_ray.collider != null;
        }
    }
    void move(float horizontal_direction)
    {
        if (horizontal_direction > 0.1f || horizontal_direction < -0.1f)
        {
            rb.velocity = new Vector2(horizontal_direction * _moving_speed, rb.velocity.y);
        }
    }
     
}

 