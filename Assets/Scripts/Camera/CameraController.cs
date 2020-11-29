using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // the distance of the camera to the player
    Vector3 camera_offset;

    void Start()
    {
        if (player == null)
            Debug.LogError("Player not set on the camara controller script, in camera element");

        camera_offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + camera_offset;
    }
}
