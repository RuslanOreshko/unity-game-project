using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerFacing : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private PlayerInputHandler input;

    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        if (input.MoveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (input.MoveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}