using UnityEngine;

public class CameraManager : MonoBehaviour {

    public enum CameraMode { 
        Follow,
        Lock,
    };

    public GameObject player;
    public float followSpeed = 5f;
    public float deadZoneWidth = 5f;
    public float deadZoneHeight = 10f;

    public CameraMode mode = CameraMode.Follow;

    private Vector2 lockPos;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    public void Lock(Vector2 pos) {
        lockPos = pos;
        mode = CameraMode.Lock;
    }

    public void Unlock() {
        mode = CameraMode.Follow;
    }

    void LateUpdate() {
        if (player && mode == CameraMode.Follow) {
            FollowPlayer();
        } else if (mode == CameraMode.Lock) {
            UpdateCamera(lockPos);
        }
    }

    void FollowPlayer() {
        Vector3 cameraPosition = transform.position;
        Vector3 playerPosition = player.transform.position + offset;

        Vector3 difference = playerPosition - cameraPosition;

        if (Mathf.Abs(difference.x) >= deadZoneWidth)
        {
            cameraPosition.x += (difference.x - Mathf.Sign(difference.x) * deadZoneWidth);
        }

        if (Mathf.Abs(difference.y) >= deadZoneHeight)
        {
            cameraPosition.y += (difference.y - Mathf.Sign(difference.y) * deadZoneHeight);
        }

        UpdateCamera(cameraPosition);
    }

    void UpdateCamera(Vector2 target) {
        float xNew = Mathf.Lerp(transform.position.x, target.x, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, target.y, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
