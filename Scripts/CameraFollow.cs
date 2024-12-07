using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;
        PlayerPosition.y += 1;

        transform.position = PlayerPosition;
    }
}
