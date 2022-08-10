using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] GameObject consumable;
    [SerializeField] PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerMovement.StartCoroutine(increase_speed(playerMovement));
            Destroy(consumable);
        }
        
    }

    IEnumerator increase_speed(PlayerMovement playerMovement) 
    {
        playerMovement.movingSpeed += 15f;
        yield return new WaitForSeconds(3f);
        playerMovement.movingSpeed -= 15f;
    }
}
