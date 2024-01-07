using System;
using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int lives
    {
        get;
        private set;
    }

    [field: SerializeField]
    public bool isInvincible
    {
        get;
        private set;
    }

    [field: SerializeField]
    public float invincibilityDelay
    {
        get;
        private set;
    }

    [SerializeField]
    Collider2D enemyCollisionDetector;

    [SerializeField]
    Animator anim;

    void Start()
    {
        lives = 3;
        isInvincible = false;
    }

    void Update()
    {
        if (gameObject.transform.position.y < -3)
        {
            Die();
        }
    }

    public void Die()
    {
        lives = Math.Clamp(lives - 1, 0, 3);
        if (lives > 0)
        {
            RespawnPlayer();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void RespawnPlayer()
    {
        Vector2 currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector2(currentPosition.x, 10);
        isInvincible = true;
        enemyCollisionDetector.gameObject.SetActive(false);
        anim.SetBool("isInvincible", true);
        StartCoroutine(resetInvincibility(invincibilityDelay));
    }
    
    IEnumerator resetInvincibility(float delay)
    {
        yield return new WaitForSeconds(delay);
        isInvincible = false;
        enemyCollisionDetector.gameObject.SetActive(true);
        anim.SetBool("isInvincible", false);
    }
}
