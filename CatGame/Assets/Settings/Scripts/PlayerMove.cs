using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GatherInput gatherInput;
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 12f;

    private bool facingRight = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    private void Awake()
    {
        gatherInput = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (gatherInput.jumpInput && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        gatherInput.jumpInput = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(gatherInput.valueX * speed, rb.linearVelocity.y);

        if (gatherInput.valueX > 0 && !facingRight)
        {
            Flip();
        }
        else if (gatherInput.valueX < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}