using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        Quaternion PlayerRotation = Quaternion.Euler(0, Player.transform.eulerAngles.y, 0);
        Vector3 PlayerPosition = Player.transform.position;

        PlayerPosition.y += 1;

        transform.position = PlayerPosition;
        transform.rotation *= PlayerRotation;
    }
}