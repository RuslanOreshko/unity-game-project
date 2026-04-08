using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(
            groundPoint.position,
            groundRadius,
            groundLayer
        );
    }
}
