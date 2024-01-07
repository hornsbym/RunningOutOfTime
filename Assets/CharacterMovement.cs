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

    private Rigidbody2D rb;

    public CharacterMovementStates state;

    // Tracks rising/falling for sprite
    private Vector2 prevPos;

    void Start()
    {
        state = CharacterMovementStates.RUNNING;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        gameObject.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        Physics.SyncTransforms();

        print(prevPos.y - transform.position.y);
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
                        print("ROlling stopped");
                    }
                    StartCoroutine(StopRolling(.65f));
                }
            }
        }
        prevPos = transform.position;
        print("State:" + state + ", " + (int)state);
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
