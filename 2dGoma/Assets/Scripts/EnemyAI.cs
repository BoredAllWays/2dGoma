using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public bool can_follow;
    public float speed = 5f;
    float max_speed = 30f;
    float acceleration = 2f;
    Transform player;
    private bool time_has_passed;
    bool player_is_killed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(wait_until_follow(speed));
    }


    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player_is_killed = true;

        if (time_has_passed && !player_is_killed && can_follow)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            speed += acceleration * Time.deltaTime;
            if (speed > max_speed)
                speed = max_speed;
        }

    }

    IEnumerator wait_until_follow(float speed)
    {
        yield return new WaitForSeconds(3f);
        time_has_passed = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(collision.gameObject);
        }

    }
}
