using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isGrounded = true; // Simple ground check flag
    public AudioClip SoundEffect;
    public AudioSource AS;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // Prevent unwanted rotations
        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Set horizontal velocity
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Flip sprite
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }

        // Jump (only if grounded)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Prevent double-jumping
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Fruit"))
        {
            Debug.Log("Fruit collected! Playing sound.");
            GameManager.instance.AddScore(1);
            AS.PlayOneShot(SoundEffect);  // plays from player’s AudioSource
            Destroy(collision.gameObject); // safe to destroy fruit
        }
        else if (collision.gameObject.CompareTag("GoldFruit"))
        {
            Debug.Log("Gold fruit collected! Playing sound.");
            GameManager.instance.AddScore(3);
            AS.PlayOneShot(SoundEffect);
            Destroy(collision.gameObject);
        }        
    }
}