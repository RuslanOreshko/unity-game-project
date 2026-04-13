using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private PlayerInputHandler input;

    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        float speed = Mathf.Abs(input.MoveInput.x);
        animator.SetFloat("Speed", speed);
    }
}