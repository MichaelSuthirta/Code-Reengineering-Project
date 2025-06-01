using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float camMoveTime = 0.25f;
    private Vector3 camOffset;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("CameraFollow: Player Transform not assigned.");
            enabled = false;
            return;
        }

        camOffset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = GetTargetCameraPosition();
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, camMoveTime);
    }

    private Vector3 GetTargetCameraPosition()
    {
        return player.position + camOffset;
    }
}

