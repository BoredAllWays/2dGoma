using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Transform player;
    Vector3 target_position;
    Vector3 velocity = Vector3.zero;
    bool is_player_killed;
    private void Update()
    {
        if (player == null)
            is_player_killed = true;
    }
    void LateUpdate()
    {
        if (!is_player_killed)
        {
            target_position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target_position, ref velocity, 0.25f);
        }
    }
}
