using System;
using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    public AudioSource jumpSound;

    [SerializeField]
    private Rigidbody2D rb;

    public CharacterMovementStates state;

    // Tracks rising/falling for sprite
    private Vector2 prevPos;

    [field: SerializeField]
    public bool isGameStarted {
        get;
        private set;
    }

    void Start()
    {
        state = CharacterMovementStates.FALLING;
        rb.isKinematic = true;
        isGameStarted = false;
    }

    public void Begin()
    {
        print("Begin called");
        isGameStarted = true;
        rb.isKinematic = false;
    }

    void Update()
    {
        if (!isGameStarted)
        {
            anim.SetInteger("state", (int) state);
            return;
        }

        gameObject.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        Physics.SyncTransforms();

        if ((prevPos - (Vector2)transform.position).y > 0.01)
        {
            // Falling
            state = CharacterMovementStates.FALLING;

        }
        else if ((prevPos - (Vector2)transform.position).y < -0.01)
        {
            // Rising
            state = CharacterMovementStates.RISING;
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (state == CharacterMovementStates.RUNNING)
                {
                    rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                    jumpSound.PlayOneShot(jumpSound.clip, 1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (state == CharacterMovementStates.RUNNING)
                {
                    state = CharacterMovementStates.ROLLING;
                    IEnumerator StopRolling(float delaySecs)
                    {
                        yield return new WaitForSeconds(delaySecs);
                        state = CharacterMovementStates.RUNNING;
                    }
                    StartCoroutine(StopRolling(.5f));
                }
            }
        }
        prevPos = transform.position;
        anim.SetInteger("state", (int)state);
    }

    void OnCollisionEnter2D()
    {
        state = CharacterMovementStates.RUNNING;
    }

    void OnCollisionStay2D()
    {
        if (state != CharacterMovementStates.ROLLING)
        {
            state = CharacterMovementStates.RUNNING;
        }
    }

    void OnCollisionExit2D()
    {
        state = CharacterMovementStates.RISING;
    }
}

public enum CharacterMovementStates
{
    IDLE, // 0
    JUMPING, // 1
    ROLLING, // 2
    RUNNING, // 3
    RISING, // 4
    FALLING, // 5
}
