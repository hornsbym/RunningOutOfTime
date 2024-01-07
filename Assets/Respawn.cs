using System;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int lives {
        get;
        private set;
    }

    void Start()
    {
        lives = 3;
    }

    void Update()
    {
        if (gameObject.transform.position.y < -3) 
        {
            Die();
        }
    }

    void Die() 
    {
        lives = Math.Clamp(lives - 1, 0, 3);
        if (lives > 0)
        {
            RespawnPlayer();
        } else 
        {
            Destroy(gameObject);
        }
    }

    void RespawnPlayer()
    {
        Vector2 currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector2(currentPosition.x, 10);
    }
}
