using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GroundCheck groundCheck;

    private PlayerInputHandler input;

    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        float speed = Mathf.Abs(input.MoveInput.x);
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsGrounded", groundCheck.IsGrounded);
    }
}