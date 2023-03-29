using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance { get; private set; }

    [SerializeField] private Animator animator;
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float doubleJumpForce = 3f;

    [SerializeField] private ParticleSystem particleSystem;

    private Rigidbody rb;
    private bool isGrounded = true;
    public bool canDoubleJump { private get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get movement input from user
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Set animator blend tree parameters
        float speed = isRunning ? runSpeed : walkSpeed;

        if(isGrounded)
        {
            animator.SetFloat("Y", vertical * speed / walkSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("X", horizontal * speed / walkSpeed, 0.1f, Time.deltaTime);
        }

        animator.SetBool("isGrounded", isGrounded);

        // Move character
        Vector3 direction = transform.forward * vertical;
        direction += transform.right * horizontal;
        direction.Normalize();
        direction *= speed;
        direction.y = rb.velocity.y;
        rb.velocity = direction;

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce);
                isGrounded = false;

                animator.CrossFade("Jump", 0.1f);
            }
            else if (canDoubleJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(Vector3.up * doubleJumpForce);
                canDoubleJump = false;

                animator.CrossFade("Flip", 0.1f);
                particleSystem.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}