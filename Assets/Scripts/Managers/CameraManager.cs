using UnityEngine;

public class CameraManager : MonoBehaviour {

    public enum CameraMode { 
        Free,
        BossFight,
    };

    public GameObject player;
    public float deadZoneWidth = 5f;
    public float deadZoneHeight = 10f;

    public CameraMode mode = CameraMode.Free;

    void LateUpdate() {
        if (player && mode == CameraMode.Free) {
            FollowPlayer();
        }
    }

    void FollowPlayer() {
        Vector3 cameraPosition = transform.position;
        Vector3 playerPosition = player.transform.position;

        Vector3 difference = playerPosition - cameraPosition;

        if (Mathf.Abs(difference.x) >= deadZoneWidth)
        {
            cameraPosition.x += (difference.x - Mathf.Sign(difference.x) * deadZoneWidth);
        }

        if (Mathf.Abs(difference.y) >= deadZoneHeight)
        {
            cameraPosition.y += (difference.y - Mathf.Sign(difference.y) * deadZoneHeight);
        }


        transform.position = cameraPosition;
    }
}
