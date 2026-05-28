using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 2f;

    private Transform targetPoint;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        targetPoint = pointB;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }

        Vector3 scale = transform.localScale;

        scale.x = direction.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerDeath>().SendMessage("Die");
        }
    }

    public void SetDreamMode(bool isDream)
    {
        if (isDream)
        {
            moveSpeed *= 10f;
        }
        else
        {
            moveSpeed /= 10f;
        }
    }
}