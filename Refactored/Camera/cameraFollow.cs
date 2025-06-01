using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Reference to the player (assign in Inspector)
    [SerializeField] private Transform player;

    // Time it takes for the camera to reach the target
    [SerializeField] private float camMoveTime = 0.25f;

    // Camera offset from the player
    private Vector3 camOffset;

    // Internal velocity tracker for SmoothDamp
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

    void LateUpdate() // ✅ Use LateUpdate to follow after player movement
    {
        Vector3 targetPosition = GetTargetCameraPosition();
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, camMoveTime);
    }

    /// <summary>
    /// Calculates the desired camera position based on player and offset.
    /// </summary>
    /// <returns>Target position for the camera.</returns>
    private Vector3 GetTargetCameraPosition()
    {
        return player.position + camOffset;
    }
}

