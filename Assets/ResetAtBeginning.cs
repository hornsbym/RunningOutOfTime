using UnityEditor.EditorTools;
using UnityEngine;

public class ResetAtBeginning : MonoBehaviour
{
    [SerializeField]
    CharacterMovement player;

    [SerializeField]
    GameObject background;

    [SerializeField]
    GameObject playerRestartSpot;

    [SerializeField]
    GameObject bgRestartSpot;

    [SerializeField]
    [Tooltip("Additive")]
    float newGameSpeedBoostAmount;
    [SerializeField]
    playMusic Music;
    void OnCollisionEnter2D(Collision2D col) 
    {
        player.transform.position = new Vector2(playerRestartSpot.transform.position.x, player.transform.position.y);
        background.transform.position = bgRestartSpot.transform.position;
        player.speed += newGameSpeedBoostAmount;
        Music.loops = 0;
    }
}
