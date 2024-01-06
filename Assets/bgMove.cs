using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour
{

    [SerializeField]
    private CharacterMovement player;
    [SerializeField]
    private float speedOffset;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector2((player.speed - speedOffset) * Time.deltaTime, 0));
    }
}
