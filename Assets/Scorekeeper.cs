using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField]
    CharacterMovement player;

    [field: SerializeField]
    public float scoreMultiplier {
        get;
        private set;
    }

    public float score {
        get;
        private set;
    }

    void Start() 
    {
        score = 0;
    }
    
    void Update() {
        if (player != null) {
            score += player.speed * scoreMultiplier * Time.deltaTime;
        }
    }
}
