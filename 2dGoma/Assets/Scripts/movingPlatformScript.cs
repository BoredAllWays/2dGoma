using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movingPlatformScript : MonoBehaviour
{
    public Transform orgin_location;
    public Transform target_location;
    private Vector3 next_position;
    private float platform_speed;
    Rigidbody2D player;
    private void Awake()
    {
        System.Random random = new System.Random();
        platform_speed = random.Next(5, 10);
        print(platform_speed);
        next_position = orgin_location.position;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log(next_position);

        if (transform.position == orgin_location.position) 
            next_position = target_location.position;

        else if (transform.position == target_location.position) 
            next_position = orgin_location.position;

        transform.position = Vector3.MoveTowards(transform.position, next_position, platform_speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.parent.rotation.z >= 1)
        {
            collision.gameObject.transform.SetParent(transform);
            player.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.transform.SetParent(null);
    }

}
