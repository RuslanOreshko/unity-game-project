using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2  MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public float JumpBufferTimer { get; private set; }
    private PlayerInputActions inputActions;
    [SerializeField] private float jumpBufferTime = 0.12f;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        MoveInput = inputActions.Player.Move.ReadValue<Vector2>();
        
        if (JumpBufferTimer > 0)
            JumpBufferTimer -= Time.deltaTime;

        if (inputActions.Player.Jump.WasCompletedThisFrame())
            JumpBufferTimer = jumpBufferTime;
    }

    public bool ConsumeJumpBuffered()
    {
        if(JumpBufferTimer <= 0) return false;

        JumpBufferTimer = 0;
        return true;
    }
}
