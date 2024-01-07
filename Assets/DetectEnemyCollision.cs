using UnityEngine;

public class DetectEnemyCollision : MonoBehaviour
{
    [SerializeField]
    Respawn playerRespawn;

    void OnCollisionEnter2D(Collision2D col)
    {
        playerRespawn.Die();
    }

}
