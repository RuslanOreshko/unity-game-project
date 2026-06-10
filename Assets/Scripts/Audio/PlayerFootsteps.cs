using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private GroundCheck groundCheck;

    private AudioSource audioSource;
    private PlayerInputHandler input;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        bool isMoving =
            Mathf.Abs(input.MoveInput.x) > 0.1f &&
            groundCheck.IsGrounded;

        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}   