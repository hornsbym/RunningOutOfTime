using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        gameObject.transform.Translate(new Vector2(speed, 0));
    }
}
