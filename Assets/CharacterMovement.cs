using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rb;
    private bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    void Update()
    {
        gameObject.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        Physics.SyncTransforms();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump) {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionStay2D() {
        canJump = true;
    }

    void OnCollisionExit2D() {
        canJump = false;
    }
}
