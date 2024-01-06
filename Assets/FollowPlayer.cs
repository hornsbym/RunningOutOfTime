using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Vector2 playerPosition;

    void Start()
    {
        playerPosition = player.transform.position;
    }

    void Update()
    {
        CalculateXOffset();
    }

    void CalculateXOffset()
    {
        Vector2 offset =  (Vector2) player.transform.position - playerPosition;

        //// Apply offset to camera position
        transform.Translate(offset);
        print(offset.x);

        playerPosition = player.transform.position;
    }
}
