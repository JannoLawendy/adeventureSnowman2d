// // // // using UnityEngine;

// // // // public class PurlyMovement : MonoBehaviour
// // // // {
// // // //     public float moveSpeed = 5f;
// // // //     public float jumpForce = 8f;

// // // //     private Rigidbody2D rb;
// // // //     private bool isGrounded;
// // // //     private Animator animator;

// // // //     void Start()
// // // //     {
// // // //         rb = GetComponent<Rigidbody2D>();
// // // //         animator = GetComponent<Animator>();
// // // //     }

// // // //     void Update()
// // // //     {
// // // //         float moveInput = Input.GetAxisRaw("Horizontal");

// // // //         // Move left/right
// // // //         rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

// // // //         // Flip Purly left/right
// // // //         if (moveInput > 0)
// // // //         {
// // // //             transform.localScale = new Vector3(1, 1, 1);
// // // //         }
// // // //         else if (moveInput < 0)
// // // //         {
// // // //             transform.localScale = new Vector3(-1, 1, 1);
// // // //         }

// // // //         // Jump
// // // //         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
// // // //         {
// // // //             rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
// // // //             isGrounded = false;
// // // //         }

// // // //         // Animator values
// // // //         if (animator != null)
// // // //         {
// // // //             animator.SetFloat("Speed", Mathf.Abs(moveInput));
// // // //             animator.SetBool("IsGrounded", isGrounded);
// // // //             animator.SetFloat("YVelocity", rb.linearVelocity.y);
// // // //         }
// // // //     }

// // // //     private void OnCollisionEnter2D(Collision2D collision)
// // // //     {
// // // //         if (collision.gameObject.CompareTag("Ground"))
// // // //         {
// // // //             isGrounded = true;
// // // //         }
// // // //     }
// // // // }
// // // using UnityEngine;

// // // public class PurlyMovement : MonoBehaviour
// // // {
// // //     public float moveSpeed = 5f;
// // //     public float jumpForce = 8f;

// // //     private Rigidbody2D rb;
// // //     private bool isGrounded;
// // //     private Animator animator;

// // //     private Vector3 originalScale; // 🔥 important

// // //     void Start()
// // //     {
// // //         rb = GetComponent<Rigidbody2D>();
// // //         animator = GetComponent<Animator>();

// // //         originalScale = transform.localScale; // save original size
// // //     }

// // //     void Update()
// // //     {
// // //         float moveInput = Input.GetAxisRaw("Horizontal");

// // //         // Move left/right
// // //         rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

// // //         // ✅ FIXED FLIP (keeps original size)
// // //         if (moveInput > 0)
// // //         {
// // //             transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
// // //         }
// // //         else if (moveInput < 0)
// // //         {
// // //             transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
// // //         }

// // //         // Jump
// // //         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
// // //         {
// // //             rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
// // //             isGrounded = false;
// // //         }

// // //         // Animator
// // //         if (animator != null)
// // //         {
// // //             animator.SetFloat("Speed", Mathf.Abs(moveInput));
// // //             animator.SetBool("IsGrounded", isGrounded);
// // //             animator.SetFloat("YVelocity", rb.linearVelocity.y);
// // //         }
// // //     }

// // //     private void OnCollisionEnter2D(Collision2D collision)
// // //     {
// // //         if (collision.gameObject.CompareTag("Ground"))
// // //         {
// // //             isGrounded = true;
// // //         }
// // //     }
// // // }



// using UnityEngine;

// public class PurlyMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public float jumpForce = 10f;

//     private Rigidbody2D rb;
//     private bool isGrounded;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         float moveInput = Input.GetAxisRaw("Horizontal");

//         // LEFT / RIGHT movement
//         rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

//         // Flip character
//         if (moveInput > 0)
//             transform.localScale = new Vector3(1, 1, 1);
//         else if (moveInput < 0)
//             transform.localScale = new Vector3(-1, 1, 1);

//         // JUMP
//         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//         {
//             rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//         }
//     }

//     // Detect ground
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isGrounded = true;
//         }
//     }

//     private void OnCollisionExit2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isGrounded = false;
//         }
//     }
// }



// // using UnityEngine;
// // using UnityEngine.SceneManagement;

// // public class PurlyMovement : MonoBehaviour
// // {
// //     public float moveSpeed = 5f;
// //     public float jumpForce = 10f;

// //     private Rigidbody2D rb;
// //     private Animator animator;
// //     private bool isGrounded;
// //     private Vector3 originalScale;

// //     void Start()
// //     {
// //         rb = GetComponent<Rigidbody2D>();
// //         animator = GetComponent<Animator>();
// //         originalScale = transform.localScale;
// //     }

// //     void Update()
// //     {
// //         float moveInput = Input.GetAxisRaw("Horizontal");

// //         // Move left / right
// //         rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

// //         // Flip character but keep original size
// //         if (moveInput > 0)
// //         {
// //             transform.localScale = originalScale;
// //         }
// //         else if (moveInput < 0)
// //         {
// //             transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
// //         }

// //         // Jump
// //         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
// //         {
// //             rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
// //             isGrounded = false;

// //             if (animator != null)
// //             {
// //                 animator.SetTrigger("Jump");
// //             }
// //         }

// //         // Animator values
// //         if (animator != null)
// //         {
// //             animator.SetFloat("Speed", Mathf.Abs(moveInput));
// //             animator.SetBool("IsGrounded", isGrounded);
// //             animator.SetFloat("YVelocity", rb.linearVelocity.y);
// //         }
// //     }

// //     private void OnCollisionEnter2D(Collision2D collision)
// //     {
// //         if (collision.gameObject.CompareTag("Ground"))
// //         {
// //             isGrounded = true;
// //         }

// //         if (collision.gameObject.CompareTag("Snowball"))
// //         {
// //             Die();
// //         }
// //     }

// //     private void OnCollisionExit2D(Collision2D collision)
// //     {
// //         if (collision.gameObject.CompareTag("Ground"))
// //         {
// //             isGrounded = false;
// //         }
// //     }

// //     private void OnTriggerEnter2D(Collider2D collision)
// //     {
// //         if (collision.CompareTag("Waterfall"))
// //         {
// //             Die();
// //         }

// //         if (collision.CompareTag("Balloon"))
// //         {
// //             Destroy(collision.gameObject);
// //         }
// //     }

// //     void Die()
// //     {
// //         Debug.Log("Purly died / melted!");

// //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
// //     }
// // }



using UnityEngine;
using UnityEngine.SceneManagement;

public class PurlyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Move left / right
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Flip character but keep original size
        if (moveInput > 0)
        {
            transform.localScale = originalScale;
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }

        // Animator values
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("IsGrounded", isGrounded);
            animator.SetFloat("YVelocity", rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Snowball"))
        {
            Die();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterFall"))
        {
            Die();
        }

        if (collision.CompareTag("balloonTag"))
        {
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        Debug.Log("Purly died / melted!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}