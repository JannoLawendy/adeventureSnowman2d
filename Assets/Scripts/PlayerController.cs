// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }



using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 200f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float rotateInput;

    private bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        // Move forward/backward using Y input
        Vector2 forwardMove = (Vector2)transform.up * moveInput.y * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Rotate using separate input
        float rotationAmount = -rotateInput * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + rotationAmount);
    }

    public void Die()
    {
        isDead = true;
    }
}