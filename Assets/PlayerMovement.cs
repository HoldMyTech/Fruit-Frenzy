using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f; 
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb; 

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Flip the sprite based on movement direction
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply an upward force to the Rigidbody2D
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}