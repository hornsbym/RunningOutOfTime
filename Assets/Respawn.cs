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
    GameObject gameplayUI;

    [SerializeField]
    GameObject endGameUI;

    [SerializeField]
    GameObject startGameUI;

    [SerializeField]
    Collider2D enemyCollisionDetector;

    [SerializeField]
    Animator anim;

    [SerializeField]
    CharacterMovement movement;
    public AudioSource loseLifeSound;

    void Start()
    {
        lives = 3;
        isInvincible = false;
        startGameUI.SetActive(true);
        gameplayUI.SetActive(false);
        endGameUI.SetActive(false);
    }

    public void Begin()
    {
        movement.Begin();
        startGameUI.SetActive(false);
        gameplayUI.SetActive(true);
        endGameUI.SetActive(false);
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
        loseLifeSound.PlayOneShot(loseLifeSound.clip, 1f);
        lives = Math.Clamp(lives - 1, 0, 3);
        if (lives > 0)
        {
            RespawnPlayer();
        }
        else
        {
            Destroy(gameObject);
            startGameUI.SetActive(false);
            gameplayUI.SetActive(false);
            endGameUI.SetActive(true);
        }
    }

    void RespawnPlayer()
    {
        Vector2 currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector2(currentPosition.x, 10);
        isInvincible = true;
        enemyCollisionDetector.enabled = false;
        anim.SetBool("isInvincible", true);
        StartCoroutine(resetInvincibility(invincibilityDelay));
    }

    IEnumerator resetInvincibility(float delay)
    {
        yield return new WaitForSeconds(delay);
        isInvincible = false;
        enemyCollisionDetector.enabled = true;
        anim.SetBool("isInvincible", false);
    }
}
