using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    private Transform enemy_location;
    private float speed;
    private float acceleration;
    [SerializeField] float max_speed;
    public Transform orgin_location;
    public Transform moving_point_location;
    public Transform pos1;
    //private float distance;
    private Vector3 next_position;
    GameObject enemy_parent;

    // Start is called before the first frame update
    void Awake()
    {
        System.Random random = new System.Random();
        speed = random.Next(5, 15);
        next_position = orgin_location.position;
        enemy_parent = transform.parent.gameObject; 
        enemy_location = gameObject.GetComponent<Transform>();
        acceleration = 2f;
        //distance = (float)System.Math.Sqrt(System.Math.Pow((orgin_location.position.x - moving_point_location.position.x), 2) + System.Math.Pow((orgin_location.position.y - moving_point_location.position.y), 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > max_speed)
            speed = max_speed;

        if (speed < 0)
            speed += -(acceleration * Time.deltaTime);
        else
            speed += (acceleration * Time.deltaTime);

        if (enemy_location.position == pos1.position)
            next_position = moving_point_location.position;

        if (enemy_location.position == moving_point_location.position) 
            next_position = pos1.position;

        enemy_location.position = Vector3.MoveTowards(enemy_location.position, next_position, speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else 
            Destroy(enemy_parent);

    }
}
