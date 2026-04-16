using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [Header("Limits")]
    public float minY;
    public float maxY;

    void LateUpdate()
    {
        float clampedY = Mathf.Clamp(target.position.y, minY, maxY);

        transform.position = new Vector3(
            target.position.x,
            clampedY,
            transform.position.z
        );
    }
}