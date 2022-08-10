using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceScript : MonoBehaviour
{
    public TMP_Text text_element;
    public Transform player;
    public Transform enemy;
    bool player_is_killed = false;
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player_is_killed = true;
        if (!player_is_killed)
        {
            double distance = System.Math.Round(System.Math.Sqrt(System.Math.Pow((player.position.x - enemy.position.x), 2) + System.Math.Pow((player.position.y - enemy.position.y), 2)), 2);
            text_element.text = distance.ToString();
        }
    }
}
