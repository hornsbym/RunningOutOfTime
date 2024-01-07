using Unity.VisualScripting;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    [SerializeField]
    Respawn player;

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            player.Begin();
        }
    }
}
